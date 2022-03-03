using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PauseGlobal
{
    public static bool GameIsPaused = false;
    
    public static void Resume() {
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public static void Pause() {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
