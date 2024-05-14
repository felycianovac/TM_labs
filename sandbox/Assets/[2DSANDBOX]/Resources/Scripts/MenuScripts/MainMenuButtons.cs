
//Made by Marcin Ciepiel - SampleText in 2021 
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainMenuButtons : MonoBehaviour {


	//This Script is a button handler for Main Menu
	void Start ()
    {
        Application.targetFrameRate = 60;
	}

	//This method is used for "Single Player" button. It transfers to "SelectPlayer" scene so player could select his player before creating the world
	public void LoadSinglePlayer()
	{
		DataManager.isMultiplayer = false;
		SceneManager.LoadScene("SelectPlayer");
	}

	//This method represents "Load Game" button in Main Menu. It loads scene "Test" that loads saved data from the last saved game.
	public void LoadSavedScene()
    {
		
			//SaveGame.Instance.Load();
			DataManager.isMultiplayer = false;
			SaveGame.Instance.IsSaveGame = true;
			SceneManager.LoadScene("Test");
	}

	//This Method is for "Options" Button. It opens "Options scene"
	public void LoadSceneOptions()
    {
		SceneManager.LoadScene("Options");
	}

	//This method is pinned to "Back" Button. It comes back to MainMenu
	public void BackButton()
    {
		SceneManager.LoadScene("MainMenu");
    }

	//This Method represents "Quit Game" button. Once clicked it closes the game.
	public void ExitGame()
    {
		Application.Quit();
	}


}
