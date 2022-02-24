using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Slider volumeSlider;
    [SerializeField] Toggle fullScreen;
    Dropdown resolutionDropdown;
    void Start()
    {
        volumeSlider.value = Settings.VOLUME;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setVolume(Slider volume)
    {
        // set game volume https://alessandrofama.com/tutorials/fmod/unity/mixer
        Settings.VOLUME = volume.value;
        Debug.Log(volume.value);
    }

    public void setResolution(int resolution)
    {
        Debug.Log(resolution);
    }

    public void setFullScreen(Toggle fullscreen)
    {
        Debug.Log(fullscreen.isOn);
        //Settings.isFullScreen = isOn ? 1 : 0;
        //Screen.fullScreen = isOn;
    }
}
