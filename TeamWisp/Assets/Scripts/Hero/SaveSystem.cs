using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Hero;
using System.Text;

public static class SaveSystem
{
    public static void Save(int saveNum, SaveData data)
    {
        Debug.Log("SAVED");
        BinaryFormatter formatter = new BinaryFormatter();
        Debug.Log("THIS IS THE SAVE NUMBER:");  Debug.Log(saveNum);
        string path = Application.persistentDataPath + "/save" + saveNum.ToString() + ".wisp";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static SaveData Load(int save_to_load)
    {
        string path = Application.persistentDataPath + "/save" + save_to_load.ToString() + ".wisp";
        if (File.Exists(path))
        {
            Debug.Log("LOADED");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    // NEED TO UPDATE LOAD() CODE FOR OTHER FUNCTIONS, THINK COMBAT SYSTEM SCRIPT RELIES ON DEFAULT LOAD WITHOUT PARAMETERS
    public static SaveData Load()
    {
        string path = Application.persistentDataPath + "/save" + 0 + ".wisp";
        if (File.Exists(path))
        {
            Debug.Log("LOADED");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
