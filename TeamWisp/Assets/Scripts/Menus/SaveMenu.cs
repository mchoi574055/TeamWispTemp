using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveMenu : MonoBehaviour
{
    [SerializeField] GameObject text1;
    [SerializeField] public int save_number;
    [SerializeField] SaveData save;

    private void Start()
    {
        if (SaveSystem.Load(save_number) != null)
        {
            Debug.Log("Not null");
            save = SaveSystem.Load(save_number);
            TextMeshProUGUI meshtext1 = text1.GetComponent<TextMeshProUGUI>();
            meshtext1.text = save.display_text;
        }
    }

    public void save_click()
    {
        if (SaveSystem.Load(save_number) == null)
        {
            Debug.Log("Save clicked");
            SaveSystem.Save(save_number, save);
            TextMeshProUGUI meshtext1 = text1.GetComponent<TextMeshProUGUI>();
            meshtext1.text = save.display_text;
        }
        else
        {
            // LOAD GAME SCENES HERE
        }
    }
}
