using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Hero;

public static class SaveSystem
{
    public static int currentSave = 0;
    
    public static void Save (int saveNum, SaveData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save" + saveNum + ".wisp";
        FileStream stream = new FileStream(path, FileMode.Create);
    
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static SaveData Load()
    {
        string path = Application.persistentDataPath + "/save" + currentSave + ".wisp";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
    
            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
    
            return data;
        }else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    
    }
}
