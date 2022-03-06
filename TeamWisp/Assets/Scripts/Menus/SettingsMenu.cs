using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Slider masterVolSlider;
    [SerializeField] Slider musicVolSlider;
    [SerializeField] Slider sfxVolSlider;
    [SerializeField] Toggle fullScreenToggle;
    [SerializeField] TMPro.TMP_Dropdown resDropDown;
    [SerializeField] Slider brightnessSlider;
    [SerializeField] TMPro.TMP_Dropdown textSpeedDropDown;
    [SerializeField] TMPro.TMP_Dropdown textSizeDropDown;


    static public int[,] indexToResolution = { { 1920, 1080 }, { 2560, 1440 }, { 7680, 4320 } };
    static public float[] indexToTextSpeed = { 0.001f, 0.025f, 0.05f };
    static public float[] indexToTextSize = { 1, 5, 10 };

    

    void Start()
    {
        loadSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setMasterVolume(System.Single vol)
    {
        // set game volume https://alessandrofama.com/tutorials/fmod/unity/mixer
        Settings.master_volume = (float)vol;
        FMOD.Studio.VCA vca;
        vca = FMODUnity.RuntimeManager.GetVCA("vca:/Master");
        vca.setVolume(Mathf.Pow(10.0f, vol / 20f));   // scale volume linearly
    }

    public void setMusicVolume(System.Single vol)
    {
        Settings.music_volume = (float)vol;
        FMOD.Studio.VCA vca;
        vca = FMODUnity.RuntimeManager.GetVCA("vca:/Music");
        vca.setVolume(Mathf.Pow(10.0f, vol / 20f));   
    }

    public void setSFXVolume(System.Single vol)
    {
        Settings.sfx_volume = (float)vol;
        FMOD.Studio.VCA vca;
        vca = FMODUnity.RuntimeManager.GetVCA("vca:/SFX");
        vca.setVolume(Mathf.Pow(10.0f, vol / 20f));
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

    public void setTextSpeed(int speed)
    {
        Settings.text_speed = speed;
        // set ingame properties here
    }

    public void setTextSize(int size)
    {
        Settings.text_size = size;
        // set ingame properties here
    }


    public void loadSettings()
    {
        
        // so that the functions ONLY run at startup
        masterVolSlider.onValueChanged.AddListener( vol => setMasterVolume(vol) );
        musicVolSlider.onValueChanged.AddListener(vol => setMusicVolume(vol));
        sfxVolSlider.onValueChanged.AddListener(vol => setSFXVolume(vol));
        fullScreenToggle.onValueChanged.AddListener( isOn => setFullScreen(isOn) );
        resDropDown.onValueChanged.AddListener(val => setResolution(val) );
        brightnessSlider.onValueChanged.AddListener(delegate { setBrightness(brightnessSlider.value); });
        textSizeDropDown.onValueChanged.AddListener(val => setTextSize(val));
        textSpeedDropDown.onValueChanged.AddListener(val => setTextSpeed(val));

        // set values in settings menu
        masterVolSlider.value = Settings.master_volume;
        musicVolSlider.value = Settings.music_volume;
        sfxVolSlider.value = Settings.sfx_volume;
        fullScreenToggle.isOn = Settings.isFullScreen == 1;
        resDropDown.value = Settings.resolution;
        brightnessSlider.value = Settings.brightness;
        textSizeDropDown.value = Settings.text_size;
        textSpeedDropDown.value = Settings.text_speed;


    }

}
