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

        FMOD.Studio.VCA vca;
        vca = FMODUnity.RuntimeManager.GetVCA("vca:/Master");
        vca.setVolume(Mathf.Pow(10.0f, Settings.master_volume / 20f));   // scale volume linearly
        vca = FMODUnity.RuntimeManager.GetVCA("vca:/Music");
        vca.setVolume(Mathf.Pow(10.0f, Settings.music_volume / 20f));
        vca = FMODUnity.RuntimeManager.GetVCA("vca:/SFX");
        vca.setVolume(Mathf.Pow(10.0f, Settings.sfx_volume / 20f));

        // set text settings here
    }
}
