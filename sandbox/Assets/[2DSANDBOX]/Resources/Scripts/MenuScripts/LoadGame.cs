using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour {

	public Sprite playNormal;
	public Sprite playHover;

	public void OnMouseEnter(){
        this.gameObject.GetComponent<Image>().sprite = playHover;
	}

	public void OnMouseExit(){
        this.gameObject.GetComponent<Image>().sprite = playNormal;
	}

	public void OnMouseDown()
	{
        //Nilupul
        //SaveGame.Instance.Load();
        DataManager.isMultiplayer = false;
        SaveGame.Instance.IsSaveGame = true;
		SceneManager.LoadScene ("Test");
	}

	// Use this for initialization
	void Start () {
		
	}
}
