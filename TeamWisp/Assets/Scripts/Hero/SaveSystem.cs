using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Hero;

public static class SaveSystem 
{
    public static void SaveHero (HeroController hero)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.wisp";
        FileStream stream = new FileStream(path, FileMode.Create);

        HeroData data = new HeroData(hero);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static HeroData LoadHero()
    {
        string path = Application.persistentDataPath + "/player.wisp";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HeroData data = formatter.Deserialize(stream) as HeroData;
            stream.Close();

            return data;
        }else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }

    }
}
