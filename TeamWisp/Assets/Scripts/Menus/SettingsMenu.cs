using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Slider volSlider;
    [SerializeField] Toggle fullScreenToggle;
    [SerializeField] Dropdown resDropDown;

    void Start()
    {
        
        loadSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void setVolume(System.Single vol)
    {
        // set game volume https://alessandrofama.com/tutorials/fmod/unity/mixer
        Settings.VOLUME = (float)vol;
    }

    public void setResolution(int resolution)
    {
        Debug.Log(resolution);
        //Screen.SetResolution(width, height, Settings.isFullScreen == 1);
    }

    public void setFullScreen(bool fullScreen)
    {
        Settings.isFullScreen = fullScreen ? 1 : 0;
        Screen.fullScreen = fullScreen;
        //Screen.fullScreenMode = fullScreen ? FullScreenMode.ExclusiveFullScreen : FullScreenMode.Windowed;
    }

    public void loadSettings()
    {
        // set values in settings menu
        volSlider.value = Settings.VOLUME;
        fullScreenToggle.isOn = Settings.isFullScreen == 1;

        // change actual settings
        Screen.fullScreen = Settings.isFullScreen == 1;
        //Screen.SetResolution(width, height, Settings.isFullScreen == 1);
    }

}
