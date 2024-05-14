using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

using Debug = UnityEngine.Debug;


public static class MapLoader
{
    private static string _mapFolder = Application.persistentDataPath + "/Maps/";
	private static string _savemapPostfix = "_save";
    private static string _mapExtension = ".sect";

    /// <summary>
    /// Get the path for a specific sector taking into account the name of the map,
    /// the position of the sector and the file format defined within the game.
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    private static string getSectorPath(Vector2I position, string mapName)
    {
        string fileName = "sector_" + position.x + "_" + position.y;
        string savePostfix = SaveGame.Instance.IsSaveGame ? _savemapPostfix : "";
        string path =   mapName + savePostfix + "/" + fileName + _mapExtension;

        return path;
    }

    private static string getDir(string mapName)
    {
        string savePostfix = SaveGame.Instance.IsSaveGame ? _savemapPostfix : "";
        string path = mapName + savePostfix;

        return path;
    }


    /// <summary>
    /// Check whether or not a sectors data file exists
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public static bool sectorExists(Vector2I position, string mapName)
    {
        string path = getSectorPath(position, mapName);
        string savedPath = _mapFolder + path;

        if (File.Exists(savedPath))
            return true;
        path = "RMaps/" + path ;
        TextAsset text= Resources.Load<TextAsset>(path);
//        Debug.Log("your "+text.name);
        return text != null;
    }

    public static void saveSector(Sector sector, string mapName)
    {
		string path = _mapFolder+ getSectorPath(sector.position, mapName);

        StreamWriter writer = null;

        try
        {
			string dirPath = _mapFolder + getDir(mapName);

            if (!Directory.Exists(_mapFolder))
            {
                Directory.CreateDirectory(_mapFolder);
            }
            // Create the folder if it doesn't exist
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            writer = new StreamWriter(path);
            sector.saveData(writer);
        }
        catch(Exception e)
        {
            //Debug.Log(e.StackTrace);
            ///throw new System.Exception("FAILED");
            throw new System.Exception("Failed to save sector " + sector.position + ", error: " + e.Message + " stack, " + e.StackTrace);
        }
        finally
        {
            if(writer != null)
            {
                writer.Close();
            }
        }
    }

    public static Sector loadSector(Vector2I pos, string mapName)
    {
        Sector sector = new Sector();
        sector.setPosition(pos);

		string path = getSectorPath(sector.position, mapName);
        string savePath = _mapFolder + path;
        bool savedPathExists = File.Exists(savePath);
        
        path = "RMaps/" + path ;
        TextAsset text= Resources.Load<TextAsset>(path);
        // Does the sectors file exist yet? In Resources file or saved in persistent
        if(savedPathExists || text != null)
        {
            StreamReader reader = null;

            try
            {
                if (savedPathExists)
                    reader = new StreamReader(savePath);
                else
                {
                    MemoryStream stream = new MemoryStream(text.bytes);
                    reader = new StreamReader(stream);
                }

                sector.loadData(reader);
            }
            catch(Exception e)
            {
                Debug.Log(e.StackTrace);
                throw new Exception("Failed to read sector " + sector.position + ", error: " + e.Message);
            }
            finally
            {
                if(reader != null)
                {
                    reader.Close();
                }
            }
            Resources.UnloadAsset(text);
            return sector;
        }
        else // Sector needs generating
        {
            throw new System.Exception("Missing sector " + sector.position);
        }
    }
}
