using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Persisting Variables
    public static LevelManager instance;
    public static int sceneIndex;
    public static int lastBedIndex = 0;
    public static Vector3 respawnPoint;
    public static LevelUIManager ui;
    public static Player player;

    // Instance varibles
    public Vector3 spawnpoint;
    public Sound levelTrack;
    public Sound caveTrack;
    [HideInInspector] public Dictionary<string, PowerUp> powerUps;
    [HideInInspector] public Dictionary<string, PlayerAbility> playerAbilities;

    private void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        ui = FindObjectOfType<LevelUIManager>(true);
        player = FindObjectOfType<Player>(true);

        powerUps = getDictionaryFromArray<PowerUp>(FindObjectsOfType<PowerUp>(true));
        playerAbilities = getDictionaryFromArray<PlayerAbility>(FindObjectsOfType<PlayerAbility>(true));

        if (respawnPoint == new Vector3()) respawnPoint = spawnpoint;
        player.transform.position = respawnPoint;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            // Cleanup un-used audio sources
            Destroy(instance.levelTrack.source);
            Destroy(instance.caveTrack.source);

            // Assign references
            instance.levelTrack = levelTrack;
            instance.caveTrack = caveTrack;

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
        // Reset Variables
        Player.curHealth = 3;
        Shield.durability = 10;
        TheDragon.dragonHealth = 100;
        TheDragon.isDead = false;
        CaveBoundary.onSurface = null;
        Hints.vs.Clear();
        Portal.InEnd = false;
        lastBedIndex = 0;
        respawnPoint = new Vector3();

        // Clean up references
        Destroy(instance.levelTrack.source);
        Destroy(instance.caveTrack.source);
        instance.levelTrack = null;
        instance.caveTrack = null;
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