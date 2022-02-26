using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class PauseMenu : MonoBehaviour {

        // Serialized Fields
        [SerializeField] private string titleScreenScene = "Title Screen";

        // Lifecycle
        void Update() {
        
        }
    
        // Events

        public void OnPause()
        {
            if (PauseGlobal.GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    
        // Methods
    
        public void Resume() {
            PauseGlobal.Resume();
        }

        void Pause() {
            PauseGlobal.Pause();
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
}
