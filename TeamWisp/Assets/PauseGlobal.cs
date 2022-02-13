using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGlobal { // very confused about the static / whatever stuff also are these scripts in the wrong directory
    public static bool Resume() {
        Time.timeScale = 1f;
        bool GameIsPaused = false;
        return GameIsPaused;
    }

    public static bool Pause() {
        Time.timeScale = 0f;
        bool GameIsPaused = true;
        return GameIsPaused;
    }
}
