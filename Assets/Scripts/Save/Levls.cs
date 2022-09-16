using System;
using UnityEngine;

public class Levls : MonoBehaviour
{
    public static bool[] levels = new bool[4];

    private void Awake()
    {
        Load();
    }

    public static void Save()
    {
        SaveLoad.SaveData();
    }

    public static void Load()
    {
        PlayerData data = SaveLoad.LoadData();
        try
        {
            Array.Copy(data.Completed, levels, data.Completed.Length);
        }
        catch (Exception error)
        {
            Debug.LogWarning(error);
        }
    }
}
