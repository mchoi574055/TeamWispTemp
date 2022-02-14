using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 3;
    public int health = 40;

    public void OnLevelUp()
    {
        Debug.Log("P key was pressed");
        level += 1;
    }
    public void OnSave()
    {
            Debug.Log("s key pressed");
            SavePlayer();
        
    }

    public void OnLoad()
    {
            Debug.Log("l key pressed");
            LoadPlayer();

    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        // health = data.health

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}