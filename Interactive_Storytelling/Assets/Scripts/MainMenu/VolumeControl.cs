using UnityEngine;
using UnityEngine.UI; // Required for working with UI elements

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the UI slider

    void Start()
    {
        // Optional: Initialize your slider's value to the current volume
        volumeSlider.value = AudioListener.volume;
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
