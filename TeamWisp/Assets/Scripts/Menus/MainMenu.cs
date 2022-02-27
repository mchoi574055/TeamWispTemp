using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private string gameScene = "";
    [SerializeField] GameObject play_button;
    [SerializeField] GameObject option_button;
    [SerializeField] GameObject quit_button;

    [SerializeField] GameObject save_button1;
    [SerializeField] GameObject save_button2;
    [SerializeField] GameObject save_button3;
    [SerializeField] GameObject save_button4;

    public void PlayGame () {
        play_button.SetActive(false);
        option_button.SetActive(false);
        quit_button.SetActive(false);

        SaveMenu();
    }

    public void SaveMenu()
    {
        save_button1.SetActive(true);
        save_button2.SetActive(true);
        save_button3.SetActive(true);
        save_button4.SetActive(true);
    }

    public void QuitGame () {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}