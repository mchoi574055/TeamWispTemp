using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private string gameScene = "";

    public void QuitGame () {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}