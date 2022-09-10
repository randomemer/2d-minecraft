using System;
using UnityEngine;
using UnityEngine.UI;

public class Levls : MonoBehaviour
{
    public static bool[] levels = new bool[4];
    private void Awake()
    {
        Load();
        for (int i = 0; i < levels.Length; i++)
        {
            if (!levels[i])
            {
                Button button = GameObject.Find((i + 2).ToString()).GetComponent<Button>();
                button.interactable = false;
            }
        }
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
