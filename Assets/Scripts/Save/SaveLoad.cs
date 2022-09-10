using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{
    public static void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saves.gay";
        FileStream fileStream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData();
        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static PlayerData LoadData()
    {
        string path = Application.persistentDataPath + "/saves.gay";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();
            return data;
        }
        else
        {
            Debug.LogError("File not found");
            return null;
        }
    }
}
