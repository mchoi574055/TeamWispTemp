using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        GameIsPaused = PauseGlobal.Resume();
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        GameIsPaused = PauseGlobal.Pause();
    }

    public void LoadMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //probably need to rework this part
    }
    public void LoadSettings() { //idk how to do this part
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //probably need to rework this part
    }

    public void QuitGame() {
        Debug.Log("quit game");
        Application.Quit();
    }
}
