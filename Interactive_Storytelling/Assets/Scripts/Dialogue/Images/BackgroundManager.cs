using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEditor.SearchService;
using UnityEngine.Analytics;

public class BackgroundManager : MonoBehaviour
{
    public Story story;
    public TextAsset inkStoryAsset; // Reference to the ink story JSON file
    [SerializeField] private Image backgroundImage; // Reference to the UI Image component for the background
    [SerializeField] private Image blurImage;

    void Start() {
        if (inkStoryAsset != null) {
            story = new Story(inkStoryAsset.text);
        } else {
            Debug.LogError("Ink story asset is not assigned.");
        }
    }
    void Update()
    {
        UpdateBackgroundImage();
    }

void UpdateBackgroundImage() {
    if (story == null) {
        Debug.LogError("Story is not initialized.");
        return;
    }

    // Attempt to retrieve the value of the "sceneSetting" variable
    object sceneSettingObj = story.variablesState["sceneSetting"];

    // Check if the retrieved value is not null
    if (sceneSettingObj != null) {
        // Convert the value to string
        string sceneSetting = sceneSettingObj.ToString();
        Debug.Log($"Current sceneSetting: {sceneSetting}");

        // Now, switch based on the value of sceneSetting
        switch (sceneSetting) {
            case "default":
                break;
            case "introduction":
                backgroundImage.sprite = Resources.Load<Sprite>("scene_1");
                blurImage.sprite = Resources.Load<Sprite>("galactic");
                break;
  
        }
    } else {
        // Handle the case where "sceneSetting" variable doesn't exist or is null
        Debug.LogWarning("sceneSetting variable not found or is null in Ink story.");
    }
}



}
