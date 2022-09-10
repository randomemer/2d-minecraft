using UnityEngine;
public class GameMaster : MonoBehaviour
{
    // Reswpawn Variables
    public Vector3 spawnpoint;
    public static float prePoint;
    public static Vector3 respawnPoint;
    public static GameMaster ins;
    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
            DontDestroyOnLoad(ins);
        }
        else
        {
            Destroy(gameObject);
        }

        if (respawnPoint == new Vector3(0, 0, 0))
        {
            respawnPoint = spawnpoint;
        }
    }
    public static void ResetVar()
    {
        PlayerHealth.Health = 3;
        respawnPoint = new Vector3(0, 0, 0);
        Powerup.collected.Clear();
        Powerup.hadSword = false;
        Powerup.hadShield = false;
        Powerup.hadBow = false;
        Powerup.emeraldCount = 0;
        Powerup.eyeCount = 0;
        Doors.keyCount = 0;
        TheDragon.dragonHealth = 100;
        Hints.vs.Clear();
        Portal.InEnd = false;
    }
}

