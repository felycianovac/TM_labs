using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainOptions;
    public GameObject singlePlayerOptions;
    public GameObject InputMapName;

    private void Start()
    {
        mainOptions.SetActive(true);
        singlePlayerOptions.SetActive(false);
        InputMapName.SetActive(false);
    }

    public void OnSinglePlayerButtonClick()
    {
        DataManager.isMultiplayer = false;
        mainOptions.SetActive(false);
        singlePlayerOptions.SetActive(true);
    }

    public void OnBackButtonClick()
    {
        mainOptions.SetActive(true);
        singlePlayerOptions.SetActive(false);
    }

    public void OnMultiplayerClick()
    {
        DataManager.isMultiplayer = true;
        InputMapName.SetActive(true);
    }

    public void OnMultiplayerMapNameInput(Text name)
    {
        DataManager.multiplayerMapName = name.text;
    }

    public void OnMultiplayerNextButtonClick()
    {
        SceneManager.LoadScene("SelectPlayer");
    }
}
