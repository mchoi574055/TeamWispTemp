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
        //Settings.VOLUME = volume.value;
        Debug.Log((float)vol);
    }

    public void setResolution(int resolution)
    {
        Debug.Log(resolution);
    }

    public void setFullScreen(bool fullScreen)
    {
        Debug.Log(fullScreen);
        //Settings.isFullScreen = isOn ? 1 : 0;
        //Screen.fullScreen = isOn;
    }

    public void loadSettings()
    {
        Debug.Log("hi");
        volSlider.value = Settings.VOLUME;
    }
    
}
