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
    [SerializeField] Slider brightnessSlider;

    public int[,] indexToResolution = { { 1280, 720 }, { 1920, 1080 }, { 2560, 1440 } };

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
        Settings.resolution = resolution;
        Screen.SetResolution(indexToResolution[resolution, 0], indexToResolution[resolution, 1], Settings.isFullScreen == 1);
    }

    public void setFullScreen(bool fullScreen)
    {
        Settings.isFullScreen = fullScreen ? 1 : 0;
        Screen.fullScreen = fullScreen;
        //Screen.fullScreenMode = fullScreen ? FullScreenMode.ExclusiveFullScreen : FullScreenMode.Windowed;
    }

    public void setBrightness(System.Single bright)
    {
        Settings.brightness = (float)bright;
        Screen.brightness = (float)bright;
    }

    public void loadSettings()
    {
        // set values in settings menu
        volSlider.value = Settings.VOLUME;
        fullScreenToggle.isOn = Settings.isFullScreen == 1;
        resDropDown.value = Settings.resolution;
        brightnessSlider.value = Settings.brightness;

        // change actual settings
        Screen.fullScreen = Settings.isFullScreen == 1;
        Screen.SetResolution(indexToResolution[Settings.resolution, 0], indexToResolution[Settings.resolution, 1], Settings.isFullScreen == 1);
        Screen.brightness = Settings.brightness;
    }

}
