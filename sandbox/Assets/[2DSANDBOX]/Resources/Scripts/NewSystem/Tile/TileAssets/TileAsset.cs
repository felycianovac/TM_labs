using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New Tile", menuName = "Tiles/Tile")]
public class TileAsset : ScriptableObject
{
    public enum TileCategory
    {
        Dirt,
        Stone,
        Wood,
        Resources,
        Plants,
        HardStone,
        Unbreakable
  }

    [SerializeField]
    private int _id;
    [SerializeField]
    private int _maxHealth;
    [SerializeField]
    private TileCategory _tileCategory;
    [SerializeField]
    private Texture2D _texture;
    [SerializeField]
    private bool _specialTile;
    [SerializeField]
    private bool _backgroundTile;
    [SerializeField]
    private string _displayName;
    [SerializeField]
    private bool _visible;
    [SerializeField]
    private bool _solid;
    [SerializeField]
    private bool _opaque;
    [SerializeField]
    private bool _dropItem;
    [SerializeField]
    private Light _light;
    [SerializeField]
    private ItemAssetTile _droppedItem;
    [SerializeField]
    private GameObject _ai;

    public int id { get { return _id; } }
    public int maxHealth { get { return _maxHealth; } }
    public TileCategory tileCategory {get { return _tileCategory; } }
    public Texture2D texture { get { return _texture; } }
    public bool specialTile { get { return _specialTile; } }
    public bool backgroundTile { get { return _backgroundTile; } }
    public string displayName { get { return _displayName; } }
    public bool visible { get { return _visible; } }
    public bool solid { get { return _solid; } }
    public bool opaque { get { return _opaque; } }
    public bool dropItem { get { return _dropItem; } }
    public GameObject ai { get { return _ai; } }
    public Light light { get { return _light; } }
    public ItemAssetTile droppedItem { get { return _droppedItem; } }

    public virtual Tile getTile()
    {
        return new Tile(id, maxHealth, this);
    }
}
