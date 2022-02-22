using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Slider volumeSlider;
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

    public void setResolution(Dropdown resolution)
    {

    }
}
