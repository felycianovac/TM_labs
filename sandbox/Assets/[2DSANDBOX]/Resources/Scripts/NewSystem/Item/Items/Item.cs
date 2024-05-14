using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class Item : ISaveable
{
    private int _id;

  private bool _isEquiped;

    public int id { get { return _id; } }
    public bool IsEquiped { get { return _isEquiped; } set { _isEquiped = value; } }

    public Item()
    {
        _id = 0;
    }

    public Item(int id)
    {
        _id = id;
    }

    public virtual bool activateItem(Vector3 pos)
    {
        return true;
    }

    public void saveData(StreamWriter writer)
    {
        writer.WriteLine(_id);
    }

    public void loadData(StreamReader reader)
    {
        _id = int.Parse(reader.ReadLine());
    }
}
