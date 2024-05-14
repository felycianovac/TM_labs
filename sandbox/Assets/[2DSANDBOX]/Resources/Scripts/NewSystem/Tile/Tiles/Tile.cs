using UnityEngine;
using System.Collections;
using System;
using System.IO;

public enum ToolType
{
      Hand = -1
    , Axe = 30
    , Pickaxe = 31
    , Shovel = 32
}


public class Tile : ISaveable
{
  private int _id;
  private int _health;
  private TileAsset _asset;

  public int id { get { return _id; } }
  public int health { get { return _health; } }
  public TileAsset asset { get { return _asset; } }

  public Tile(int id, int health)
  {
    this._id = id;
    this._health = health;
    this._asset = TileStore.getTile(id);
  }

  public Tile(int id, int health, TileAsset asset)
  {
    this._id = id;
    this._health = health;
    this._asset = asset;
  }

  public virtual void saveData(StreamWriter writer)
  {
    // ID is parsed to the save data file
    writer.WriteLine(_id);
  }

  public virtual void loadData(StreamReader reader)
  {
    // ID value does not need to be re-loaded as it is used for initialization.
    // TODO : use default contstructor to assign ID in here instead.
  }

  public virtual bool isBlockSolid()
  {
    return _asset.solid;
  }

  public virtual string getTexture()
  {
    return _asset.texture.name;
  }

  public virtual void onRightClicked()
  {

  }

  public virtual void onPlaced()
  {

  }

  public virtual void onDestroyed(Vector2 position)
  {
    TileAsset tile = TileStore.getTile(id);

    if (tile.dropItem)
    {
      Debug.Log(tile);

      EntityItem item = (EntityItem)EntityStore.createEntity(0);

      Debug.Log(item);
      item.itemID = tile.droppedItem.id;

      item.transform.position = new Vector3(position.x - 0.5f, position.y - 0.5f, 1.0f);
    }
  }

  public virtual void decreaseHealth(int toolId)
  {
    int damage = 1;
    var toolType = (ToolType)toolId;

    switch (toolType)
    {
      case ToolType.Hand:
        damage = 1;
        break;
      case ToolType.Axe: //Axe
        switch (_asset.tileCategory)
        {
          case TileAsset.TileCategory.Dirt:
            damage = 2;
            break;
          case TileAsset.TileCategory.HardStone:
            damage = 1;
            break;
          case TileAsset.TileCategory.Plants:
            damage = 5;
            break;
          case TileAsset.TileCategory.Resources:
            damage = 1;
            break;
          case TileAsset.TileCategory.Stone:
            damage = 1;
            break;
          case TileAsset.TileCategory.Wood:
            damage = 5;
            break;
        }
        break;
      case ToolType.Pickaxe: //Pickaxe
        switch (_asset.tileCategory)
        {
          case TileAsset.TileCategory.Dirt:
            damage = 1;
            break;
          case TileAsset.TileCategory.HardStone:
            damage = 5;
            break;
          case TileAsset.TileCategory.Plants:
            damage = 1;
            break;
          case TileAsset.TileCategory.Resources:
            damage = 10;
            break;
          case TileAsset.TileCategory.Stone:
            damage = 15;
            break;
          case TileAsset.TileCategory.Wood:
            damage = 2;
            break;
        }
        break;
      case ToolType.Shovel: //Shovel
        switch (_asset.tileCategory)
        {
          case TileAsset.TileCategory.Dirt:
            damage = 5;
            break;
          case TileAsset.TileCategory.HardStone:
            damage = 0;
            break;
          case TileAsset.TileCategory.Plants:
            damage = 3;
            break;
          case TileAsset.TileCategory.Resources:
            damage = 0;
            break;
          case TileAsset.TileCategory.Stone:
            damage = 1;
            break;
          case TileAsset.TileCategory.Wood:
            damage = 1;
            break;
        }
        break;
    }

    _health -= damage;
  }
}