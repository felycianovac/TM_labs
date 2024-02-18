using UnityEngine;
using Ink.Runtime;
using System.IO;

public class StorySerialization
{
    // Set a path to save and restore Story.
    static string saveVariablesFileName = "currentStory.json";
    static string defaultVariablesFileName = "default.json";
    static string savePath = System.IO.Path.Combine(Application.dataPath, "Resources", saveVariablesFileName);

    // Set a default path (in case the save file does not exist).
    static string defaultPath = System.IO.Path.Combine(Application.dataPath, "Resources", defaultVariablesFileName);

    // Convert a story into a JSON string.
    static public void Serialize(TextAsset textAsset)
    {
        Story s = new Story(textAsset.text);
        // Either create or overwrite an existing story file.
        File.WriteAllText(savePath, s.ToJson());
    }

    // Create a story based on saved JSON.
    static public Story Deserialize()
    {
        // Create a story to return.
        Story s;

        // Create internal JSON string.
        string JSONContents;

        // Does the file exist?
        if (File.Exists(savePath))
        {
            // Read the entire file
            JSONContents = File.ReadAllText(savePath);
            // Create a new Story based on JSON
            s = new Story(JSONContents);
        }
        else
        {
            // File does not exist.
            // Load the default
            JSONContents = File.ReadAllText(defaultPath);
            // Create Story based on default
            s = new Story(JSONContents);
        }

        // Return either default or restored story
        return s;
        
    }
}