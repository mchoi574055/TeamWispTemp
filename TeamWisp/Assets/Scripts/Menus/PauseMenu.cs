using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    
    // Private members
    private static bool GameIsPaused = false;

    // Serialized Fields
    [SerializeField] private string titleScreenScene = "Title Screen";

    // Lifecycle
    void Update() {
        
    }
    
    // Events

    public void OnPause()
    {
        if (GameIsPaused) {
            Resume();
        } else {
            Pause();
        }
    }
    
    // Methods
    
    public void Resume() {
        GameIsPaused = PauseGlobal.Resume();
    }

    void Pause() {
        GameIsPaused = PauseGlobal.Pause();
    }

    public void LoadTitleScreenScene() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(titleScreenScene); //probably need to rework this part
    }

    public void QuitGame() {
        Debug.Log("quit game");
        Application.Quit();
    }
}
