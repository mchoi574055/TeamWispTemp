using UnityEngine;

class startClass
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoadRuntimeMethod()
    {
        Debug.Log("Running Startup Script!");
        // change settings
        Screen.fullScreen = Settings.isFullScreen == 1;
        Screen.SetResolution(SettingsMenu.indexToResolution[Settings.resolution, 0],
            SettingsMenu.indexToResolution[Settings.resolution, 1], Settings.isFullScreen == 1);
        Screen.brightness = Settings.brightness;
    }
}
