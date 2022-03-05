using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private string gameScene = "";
    
    public void PlayGame () {
        SceneManager.LoadScene(gameScene);
    }

    public void QuitGame () {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}