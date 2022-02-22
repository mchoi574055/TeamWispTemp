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
}
