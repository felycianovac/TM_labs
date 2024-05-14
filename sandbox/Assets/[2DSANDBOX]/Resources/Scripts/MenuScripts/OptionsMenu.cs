using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resolution1080()
    {
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
    }

    public void Resolution720()
    {
        Screen.SetResolution(1280, 720, Screen.fullScreen); 
    }

    public void Resolution480()
    {
        Screen.SetResolution(640, 480, Screen.fullScreen); 
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void LowQuality()
    {
        QualitySettings.SetQualityLevel(0);
    }

    public void MediumQuality()
    {
        QualitySettings.SetQualityLevel(1);
    }

    public void HighQuality()
    {
        QualitySettings.SetQualityLevel(2);
    }

}
