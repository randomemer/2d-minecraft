using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Persisting Variables
    public static LevelManager instance;
    private static int sceneIndex;
    public static int lastBedIndex = 0;
    public static Vector3 respawnPoint;
    public static LevelUIManager ui;

    // Instance varibles
    public Vector3 spawnpoint;
    [HideInInspector] public Dictionary<string, PowerUp> powerUps;
    [HideInInspector] public Dictionary<string, PlayerAbility> playerAbilities;

    private void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        ui = FindObjectOfType<LevelUIManager>();

        powerUps = getDictionaryFromArray<PowerUp>(FindObjectsOfType<PowerUp>(true));
        playerAbilities = getDictionaryFromArray<PlayerAbility>(FindObjectsOfType<PlayerAbility>(true));

        if (respawnPoint == new Vector3()) respawnPoint = spawnpoint;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            // Remember state of player abilities
            foreach (var item in playerAbilities)
            {
                if (instance.playerAbilities[item.Key].isActive) item.Value.Activate();
            }
            instance.playerAbilities = playerAbilities;

            // Remember state of collected powerUps
            foreach (var item in powerUps)
            {
                if (!item.Value.shouldRespawn && instance.powerUps[item.Key].isCollected)
                {
                    item.Value.isCollected = true;
                    item.Value.gameObject.SetActive(false);
                }
            }
            instance.powerUps = powerUps;

            // Destroy the new instance and keep the old one
            Destroy(gameObject);
        }
    }

    public static void ResetState()
    {
        Player.curHealth = 3;
        Shield.durability = 10;
        TheDragon.dragonHealth = 100;
        Hints.vs.Clear();
        Portal.InEnd = false;
        lastBedIndex = 0;
        respawnPoint = new Vector3();
        Destroy(instance);
        instance = null;
    }

    public static void LoadNewScene(int newSceneIndex, bool shouldReset)
    {
        SceneManager.LoadScene(newSceneIndex);
        if (shouldReset) ResetState();
    }

    private Dictionary<string, T> getDictionaryFromArray<T>(T[] array)
    {
        Dictionary<string, T> dict = new Dictionary<string, T>();
        foreach (var item in array)
        {
            MonoBehaviour obj = item as MonoBehaviour;
            dict.Add(obj.name, item);
        }
        return dict;
    }
}