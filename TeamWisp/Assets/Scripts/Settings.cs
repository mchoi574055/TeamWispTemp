using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Settings
{
    /* Usage:
     * To access or modify, use Settings.{property}
     * ex. 
     * Settings.VOLUME = 0.3f;
     * 
     * Or subscribe to event callback with
     * Settings.onTextDelayChanged.AddListener(YourFunc) in Awake() 
     */
    public static UnityEvent<float> onVolumeChanged = new UnityEvent<float>();
    public static float VOLUME
    {
        get
        {
            return PlayerPrefs.GetFloat("VOLUME", 1.0f);
        }
        set
        {
            PlayerPrefs.SetFloat("VOLUME", value);
            PlayerPrefs.Save();
            onVolumeChanged.Invoke(value);
        }
    }
    public static int isFullScreen
    {
        get
        {
            return PlayerPrefs.GetInt("FULL_SCREEN", 1);
        }
        set
        {
            PlayerPrefs.SetInt("FULL_SCREEN", value);
            PlayerPrefs.Save();
        }
    }
    public static int resolution
    {
        get
        {
            return PlayerPrefs.GetInt("RESOLUTION", 0);
        }
        set
        {
            PlayerPrefs.SetInt("RESOLUTION", value);
            PlayerPrefs.Save();
        }
    }
    public static float brightness
    {
        get
        {
            return PlayerPrefs.GetFloat("BRIGHTNESS", 1.0f);
        }
        set
        {
            PlayerPrefs.SetFloat("BRIGHTNESS", value);
            PlayerPrefs.Save();
            onVolumeChanged.Invoke(value);
        }
    }

}
