using System.Collections.Generic;
using UnityEngine;

public class WorldEditor : MonoBehaviour
{
    private const string _path = "ChunkMaterial";
    private ChunkWorldObject[,] _localChunks;
    private List<ChunkWorldObject> _activeChunks;
    private WorldProperties _properties;

    private Pool<ChunkWorldObject> _chunkPool;

    private MapHandler _mapHandler;
    private ChunkLoader _loader;
    private Vector2I _position;

    public static WorldEditor instance { get; private set; }

    public List<ChunkWorldObject> activeChunks { get { return _activeChunks; } }
    public WorldProperties properties { get { return _properties; } }
    public MapHandler mapHandler { get { return _mapHandler; } }
    public Vector2I loadedPosition { get { return _position; } }

    Vector2 selectionStart;
    List<List<Tile>> selectionTiles, selectionBackgroundTiles;
    bool mapLoaded;

    void Awake()
    {
        instance = this;
        if (DataManager.isMultiplayer)
        {
            _properties = Resources.Load<WorldProperties>("World Properties Multiplayer");
        }
        else
        {
            _properties = Resources.Load<WorldProperties>("World Properties");
        }

        _chunkPool = new Pool<ChunkWorldObject>();

        Atlas.initialize();
        ItemStore.initialize();
        EntityStore.initialize();
        RecipeManager.loadRecipes();
        TileStore.initialize();
        Mesher.initialize();


        return;
    }

    public void LoadMap(string mapName)
    {
        int half = (_properties.worldDimension - 1) / 2;
        Vector2I spawnPos = new Vector2I(3, 3);
        _position = spawnPos - new Vector2I(half, half);

        _mapHandler = new MapHandler(spawnPos, mapName);

        createWorld();
        createLoader(spawnPos);
        mapLoaded = true;
    }

    public void getPlayerPos()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        Vector3 playerpos = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));

        player.transform.position = playerpos;
    }

    public void saveMap(string mapName)
    {
        if (!mapLoaded)
            return;

        _mapHandler.SetMapName(mapName);
        _mapHandler.forceSaveAllSectors();
    }

    void Update()
    {
        if (mapLoaded)
        {
            Mesher.meshLoop(true);
            _mapHandler.update();
        }
    }

    private ChunkWorldObject getContainer()
    {
        ChunkWorldObject obj = _chunkPool.get();
        obj.toggleVisiblity(true);
        return obj;
    }

    private void storeContainer(ChunkWorldObject obj)
    {
        obj.toggleVisiblity(false);
        _chunkPool.store(obj);
    }

    public void loaderMoved(Vector2I centre)
    {
        int dimension = _properties.worldDimension;

        // Work out the new bottom left corner position
        int half = (dimension - 1) / 2;
        Vector2I newCorner = centre + new Vector2I(-half, -half);

        // Tell the sector map to update its loaded sectors incase we're going out of its bounds

        if (DataManager.isMultiplayer)
        {
            ////////_mapHandler.updatePosition(centre);
        }
        else
        {
            _mapHandler.updatePosition(centre);
        }

        List<Vector2I> newPoints = new List<Vector2I>();
        List<Vector2I> oldPoints = new List<Vector2I>();

        List<ChunkWorldObject> unallocated = new List<ChunkWorldObject>();
        List<ChunkWorldObject> cache = new List<ChunkWorldObject>();
        List<ChunkWorldObject> final = new List<ChunkWorldObject>();

        // Collect all the initial and new chunk positions
        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {
                newPoints.Add(newCorner + new Vector2I(i, j));
                oldPoints.Add(_position + new Vector2I(i, j));
            }
        }

        // Set the new position
        _position = newCorner;

        // Determine which chunks need to be unloaded and which need to be kept
        // by intersecting the two sets to find the matching chunks
        for (int i = 0; i < _activeChunks.Count; i++)
        {
            ChunkWorldObject chunkObj = _activeChunks[i];
            Chunk chunk = chunkObj.chunk;

            // Ideally chunks shouldn't be loaded NULL like this but catch the case where it for some
            // reason happens
            if (chunk != null)
            {
                if (newPoints.Contains(chunk.position)) // Check for intersection
                {
                    cache.Add(chunkObj);
                    final.Add(chunkObj);
                }
                else // The chunk is going to be unloaded
                {
                    chunk.RemoveLights();
                    // Clear the mesh and store it
                    chunkObj.clearMesh();
                    storeContainer(chunkObj);
                }
            }
            else // The current chunk isn't loaded so it can be re-pooled
            {
                chunkObj.clearMesh();
                storeContainer(chunkObj);
            }
        }

        // Figure out which chunks need to be loaded and re-use the previous NULL chunks
        // for the new chunk data to be loaded into
        for (int i = 0; i < newPoints.Count; i++)
        {
            Vector2I pos = newPoints[i];

            // The new point isn't already loaded so it needs to be generated
            if (!oldPoints.Contains(pos))
            {
                // Fetch the chunk data
                Chunk chunk = _mapHandler.getChunk(pos);

                // Make sure the chunk is not NULL
                if (chunk != null)
                {
                    // Get a spare chunk container
                    ChunkWorldObject obj = getContainer();

                    obj.setChunk(chunk);
                    chunk.setContainer(obj);
                    chunk.setDirtyState(true);

                    // Update the collision map
                    //     CollisionGrid.setChunk(chunk);

                    // Store the container
                    final.Add(obj);
                }
            }
        }

        // Overwrite the active chunks
        _activeChunks = final;
    }

    private void createLoader(Vector2I position)
    {
        int half = (_properties.worldDimension - 1) / 2;

        _loader = Camera.main.gameObject.AddComponent<ChunkLoader>();
        _loader.setWorldEditor(this);

        // Set the position relative to the middle
        _loader.setPosition(position);
    }

    /// <summary>
    /// Generate the worlds chunks at a loaded position
    /// </summary>
    public void createWorld()
    {
        int dimension = _properties.worldDimension;

        _localChunks = new ChunkWorldObject[dimension, dimension];
        _activeChunks = new List<ChunkWorldObject>();

        Material material = Resources.Load<Material>(_path);
        material.mainTexture = Atlas.atlas;

        // Iterate and create the initial chunks
        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {
                // Create the chunk container object
                Vector2I pos = _position + new Vector2I(i, j);
                GameObject obj = new GameObject(string.Format("Chunk {0}", pos));
                ChunkWorldObject container = obj.AddComponent<ChunkWorldObject>();
                container.setMaterial(material);
                _activeChunks.Add(container);

                Chunk chunk = _mapHandler.getChunk(pos);

                if (chunk != null)
                {
                    chunk.setContainer(container);
                    container.setChunk(chunk);
                    chunk.setDirtyState(true);

                    // Update the collision map
                    //     CollisionGrid.setChunk(chunk);
                }
                else
                {
                    container.name = "Empty Chunk";
                    container.setChunk(null);
                }
            }
        }

        return;

        // Create all the chunks and initialize them
        for (int i = 0; i < _properties.worldDimension; i++)
        {
            for (int j = 0; j < _properties.worldDimension; j++)
            {
                GameObject obj = new GameObject();
                ChunkWorldObject container = obj.AddComponent<ChunkWorldObject>();
                container.setMaterial(material);
                _localChunks[i, j] = container;

                // Load the desired chunk and set its data
                Chunk chunk = _mapHandler.getChunk(_position + new Vector2I(i, j));

                // Only attach the container if the chunk requested isn't NULL
                if (chunk != null)
                {
                    chunk.setContainer(container);
                    chunk.setDirtyState(true);
                    container.setChunk(chunk);
                }
                else
                {
                    container.name = "Empty Chunk";
                    container.setChunk(null);
                }
            }
        }
    }

    Chunk GetChunk(Vector2I chunkPosition)
    {
        for (int i = 0; i < _activeChunks.Count; i++)
        {
            Chunk chunk = _activeChunks[i].chunk;

            if (chunk != null)
                if (chunk.position == chunkPosition)
                    return chunk;
        }

        return null;
    }

    public void setBlock(Tile tile, Vector2I c, Vector2I b, int radius, bool background)
    {
        if (!mapLoaded)
            return;

        for (int x = -radius; x <= radius; x++)
        {
            for (int y = -radius; y <= radius; y++)
            {
                Vector2I blockPosition = new Vector2I(b.x + x, b.y + y);

                Vector2I chunkPosition = new Vector2I(c.x + blockPosition.x / Chunk.tileDimension, c.y + blockPosition.y / Chunk.tileDimension);

                if (blockPosition.x < 0)
                    chunkPosition = new Vector2I(chunkPosition.x - 1, chunkPosition.y);

                if (blockPosition.y < 0)
                    chunkPosition = new Vector2I(chunkPosition.x, chunkPosition.y - 1);

                blockPosition = new Vector2I(blockPosition.x % Chunk.tileDimension, blockPosition.y % Chunk.tileDimension);

                if (blockPosition.x < 0)
                    blockPosition = new Vector2I(Chunk.tileDimension + blockPosition.x, blockPosition.y);

                if (blockPosition.y < 0)
                    blockPosition = new Vector2I(blockPosition.x, Chunk.tileDimension + blockPosition.y);

                Chunk chunk = GetChunk(chunkPosition);

                if (background)
                    chunk.setBackgroundTile(tile, blockPosition);
                else
                    chunk.setTile(tile, blockPosition);
            }
        }
    }

    public void SelectionStart(Vector2 position)
    {
        if (!mapLoaded)
            return;

        selectionStart = position;
    }

    public void SelectionEnd(Vector2 position)
    {
        if (!mapLoaded)
            return;

        Vector2 start = new Vector2(Mathf.Min(selectionStart.x, position.x), Mathf.Min(selectionStart.y, position.y));
        Vector2 end = new Vector2(Mathf.Max(selectionStart.x, position.x), Mathf.Max(selectionStart.y, position.y));

        selectionTiles = new List<List<Tile>>();
        selectionBackgroundTiles = new List<List<Tile>>();

        for (float x = start.x; x <= end.x; x += 1.0f)
        {
            selectionTiles.Add(new List<Tile>());
            selectionBackgroundTiles.Add(new List<Tile>());

            for (float y = start.y; y <= end.y; y += 1.0f)
            {
                Vector2 pos = new Vector2(x, y);
                Vector2I chunk = chunkPositionFromWorld(pos);
                Vector2I block = blockFromChunk(chunk, pos);

                Debug.Log(chunk.x + "    " + chunk.y + "    " + block.x + "    " + block.y);

                selectionTiles[selectionTiles.Count - 1].Add(GetChunk(chunk).getTile(block.x, block.y));
                selectionBackgroundTiles[selectionBackgroundTiles.Count - 1].Add(GetChunk(chunk).getBackground(block.x, block.y));
            }
        }
    }

    public void Paste(Vector2 position)
    {
        if (!mapLoaded)
            return;

        for (int x = 0; x < selectionTiles.Count; x++)
        {
            for (int y = 0; y < selectionTiles[x].Count; y++)
            {
                Vector2 pos = new Vector2(position.x + x, position.y + y);
                Vector2I chunk = chunkPositionFromWorld(pos);
                Vector2I block = blockFromChunk(chunk, pos);

                //Debug.Log(chunk.x + "    " + chunk.y + "    " + block.x + "    " + block.y);

                Chunk c = GetChunk(chunk);

                if (c != null)
                {
                    c.setTile(selectionTiles[x][y], block);
                    c.setBackgroundTile(selectionBackgroundTiles[x][y], block);
                }
            }
        }
    }

    public Vector2I chunkPositionFromWorld(Vector2 pos)
    {
        return new Vector2I(Mathf.FloorToInt((pos.x / Chunk.tileDimension)), Mathf.FloorToInt((pos.y / Chunk.tileDimension)));
    }

    public Vector2I blockPositionFromWorld(Vector2I chunkPos, Vector2 pos)
    {
        return new Vector2I(Mathf.FloorToInt(pos.x - (chunkPos.x * Chunk.tileDimension)), Mathf.FloorToInt(pos.y - (chunkPos.y * Chunk.tileDimension)));
    }

    public Vector2I blockFromChunk(Vector2I chunk, Vector2 raw)
    {
        Vector2I cut = new Vector2I(chunk.x * Chunk.tileDimension, chunk.y * Chunk.tileDimension);
        return new Vector2I(Mathf.FloorToInt(raw.x) - cut.x, Mathf.FloorToInt(raw.y) - cut.y);
    }
}