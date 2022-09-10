using System;
[System.Serializable]
public class PlayerData
{
    public bool[] Completed = new bool[4];
    public PlayerData()
    {
        Array.Copy(Levls.levels, Completed, 4);
    }
}
