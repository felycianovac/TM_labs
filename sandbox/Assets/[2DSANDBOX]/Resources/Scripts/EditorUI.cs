using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class EditorUI : MonoBehaviour
{
    public Button tile;
    public InputField brushSize;
    public InputField mapName;
    public Text textPosition;
    int tileColumns = 5;
    float space = 45.0f;
    int selectTileId;
    Tool tool;
    bool selecting;
    Vector2 selectingStart;
    Vector2 selectingEnd;
    Texture2D selectingTexture;
    bool mouseLeftPressed;
    bool mouseRightPressed;
    bool prevMouseLeftPressed;
    bool prevMouseRightPressed;
    Vector2I prevChunk;
    Vector2I prevBlock;

    enum Tool
    {
        None,
        Tile,
        Select,
        Paste
    }

    private void Start()
    {
        CreateTiles();

        selectingTexture = new Texture2D(1, 1);
        selectingTexture.SetPixel(0, 0, new Color(1.0f, 1.0f, 1.0f, 0.5f));
        selectingTexture.Apply();
    }

    private void CreateTiles()
    {
        int row = 0;
        int column = 0;
        TileAsset[] tileAssets = TileStore.getAllTiles();
        Vector2 tilePos = tile.transform.position;

        for (int i = 0; i < tileAssets.Length; i++)
        {
            Texture2D tex = tileAssets[i].texture;

            if (!tex)
                tex = Texture2D.whiteTexture;

            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
            Button button;

            if (i > 0)
                button = Instantiate(tile, tilePos + new Vector2(space * column, -space * row), Quaternion.identity, tile.transform.parent);
            else
                button = tile;

            button.name = tileAssets[i].id.ToString();
            button.image.sprite = sprite;
            button.onClick.AddListener(SelectTile);
            Rect rect = tile.transform.parent.GetComponent<RectTransform>().rect;
            //rect.height = space * i;
            
            tile.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, space * row);

            if (column + 1 >= tileColumns)
            {
                column = 0;
                row++;
            }
            else
                column++;
        }
    }

    private void SelectTile()
    {
        tool = Tool.Tile;
        selectTileId = int.Parse(EventSystem.current.currentSelectedGameObject.name);
    }

    private void Update()
    {
        if (Input.mousePosition.x < 250) // panel boczny
        {
            mouseLeftPressed = false;
            mouseRightPressed = false;
            return;
        }

        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        pos += new Vector3(0.5f, 0.5f);

        if (pos.x > Character.worldSize.x || pos.x < -Character.worldSize.x || pos.y > Character.worldSize.y || pos.y < -Character.worldSize.y)
        {
            mouseLeftPressed = false;
            mouseRightPressed = false;
            return;
        }

        textPosition.text = "x: " + pos.x.ToString("n0") + ", y: " + pos.y.ToString("n0");

        Vector2I c = WorldEditor.instance.chunkPositionFromWorld(pos);
        Vector2I b = WorldEditor.instance.blockFromChunk(c, pos);

        int radius = int.Parse(brushSize.text) - 1;

        if (Input.GetMouseButtonDown(0))
            mouseLeftPressed = true;
        if (Input.GetMouseButtonUp(0))
            mouseLeftPressed = false;
        if (Input.GetMouseButtonDown(1))
            mouseRightPressed = true;
        if (Input.GetMouseButtonUp(1))
            mouseRightPressed = false;

        if (tool == Tool.Tile)
        {
            Debug.Log("1");
            if ((c != prevChunk || b != prevBlock) || mouseLeftPressed != prevMouseLeftPressed)
            {
                if (mouseLeftPressed)
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                        WorldEditor.instance.setBlock(TileStore.getTile(selectTileId).getTile(), c, b, radius, true);
                    else
                        WorldEditor.instance.setBlock(TileStore.getTile(selectTileId).getTile(), c, b, radius, false);
                }
            }

            if ((c != prevChunk || b != prevBlock) || mouseRightPressed != prevMouseRightPressed)
            { 
                if (mouseRightPressed)
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                        WorldEditor.instance.setBlock(new Tile(0, 0), c, b, radius, true);
                    else
                        WorldEditor.instance.setBlock(new Tile(0, 0), c, b, radius, false);
                }
            }
        }
        else if (tool == Tool.Select)
        {
            Debug.Log("2");
            if (Input.GetMouseButtonDown(0))
            {
                selectingStart = Input.mousePosition;
                selecting = true;
                WorldEditor.instance.SelectionStart(pos);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                selecting = false;
                selectingStart = Vector2.zero;
                selectingEnd = Vector2.zero;
                WorldEditor.instance.SelectionEnd(pos);
            }

            if (selecting)
            {
                selectingEnd = Input.mousePosition;
            }
        }
        else if (tool == Tool.Paste)
        {
            Debug.Log("3");
            if (Input.GetMouseButtonDown(0))
            {
                WorldEditor.instance.Paste(pos);
            }
        }

        prevChunk = c;
        prevBlock = b;
        prevMouseLeftPressed = mouseLeftPressed;
        prevMouseRightPressed = mouseRightPressed;
    }

    void OnGUI()
    {
        if (selectingStart != Vector2.zero && selectingEnd != Vector2.zero)
        {
            Rect rect = new Rect(selectingStart.x, Screen.height - selectingStart.y, selectingEnd.x - selectingStart.x, -1 * (selectingEnd.y - selectingStart.y));
            GUI.DrawTexture(rect, selectingTexture);
        }
    }

    public void SelectButton()
    {
        tool = Tool.Select;
    }

    public void PasteButton()
    {
        tool = Tool.Paste;
    }

    public void SaveMap()
    {
        WorldEditor.instance.saveMap(mapName.text);
    }

    public void LoadMap()
    {
        WorldEditor.instance.LoadMap(mapName.text);
    }
}