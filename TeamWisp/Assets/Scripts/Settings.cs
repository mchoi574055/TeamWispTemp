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

    public static int text_speed
    {
        get
        {
            return PlayerPrefs.GetInt("TEXT_SPEED", 1);
        }
        set
        {
            PlayerPrefs.SetInt("TEXT_SPEED", value);
            PlayerPrefs.Save();
        }
    }
    public static int text_size
    {
        get
        {
            return PlayerPrefs.GetInt("TEXT_SIZE", 1);
        }
        set
        {
            PlayerPrefs.SetInt("TEXT_SIZE", value);
            PlayerPrefs.Save();
        }
    }
    public static float master_volume
    {
        get
        {
            return PlayerPrefs.GetFloat("MASTER_VOLUME", 1.0f);
        }
        set
        {
            PlayerPrefs.SetFloat("MASTER_VOLUME", value);
            PlayerPrefs.Save();
        }
    }
    public static float music_volume
    {
        get
        {
            return PlayerPrefs.GetFloat("MUSIC_VOLUME", 1.0f);
        }
        set
        {
            PlayerPrefs.SetFloat("MUSIC_VOLUME", value);
            PlayerPrefs.Save();
        }
    }
    public static float sfx_volume
    {
        get
        {
            return PlayerPrefs.GetFloat("SFX_VOLUME", 1.0f);
        }
        set
        {
            PlayerPrefs.SetFloat("SFX_VOLUME", value);
            PlayerPrefs.Save();
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
        }
    }

}
