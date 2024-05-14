using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_NewScene : MonoBehaviour
{
    public void LoadNewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
