using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject player;
    Hints hints;
    public static bool hadShield = false;
    public static bool hadSword = false;
    public static bool hadBow = false;

    public static int emeraldCount = 0;
    public static int eyeCount = 0;

    // other
    bool called = true;
    bool called1 = true;
    bool called2 = true;
    bool called3 = true;
    bool called4 = true;
    bool called5 = true;
    public CharacterController2D x;
    public GameObject Bubble;
    public GameObject Portal;
    public static List<string> collected = new List<string>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.name == "ShieldUP")
        {
            player.transform.GetChild(0).gameObject.SetActive(true);
            Shield.durability = 10;
            Destroy(gameObject);
            hadShield = true;
            hints.DisplayHint(gameObject.name);
            FindObjectOfType<AudioManager>().PLay("powerup");
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.name == "SwordUP")
        {
            if (hadBow)
            {
                player.transform.GetChild(2).gameObject.SetActive(false);
                hadBow = false;
            }
            player.transform.GetChild(1).gameObject.SetActive(true);
            Destroy(gameObject);
            hadSword = true;
            hints.DisplayHint(gameObject.name);
            FindObjectOfType<AudioManager>().PLay("powerup");
        }
        if (collision.gameObject.name == "Player" && gameObject.name.Contains("Lever"))
        {
            Doors.keyCount += 1;
            Destroy(gameObject);
            collected.Add(gameObject.name);
            FindObjectOfType<AudioManager>().PLay("powerup");
        }
        if (collision.gameObject.name == "Player" && gameObject.name == "BowUP")
        {
            if (hadSword)
            {
                player.transform.GetChild(1).gameObject.SetActive(false);
                hadSword = false;
            }
            player.transform.GetChild(2).gameObject.SetActive(true);
            Destroy(gameObject);
            hadBow = true;
            hints.DisplayHint(gameObject.name);
            FindObjectOfType<AudioManager>().PLay("powerup");
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.name.Contains("Elytra"))
        {
            player.transform.GetChild(3).gameObject.SetActive(true);
            Destroy(gameObject);
            x.Fly();
            hints.DisplayHint(gameObject.name);
            FindObjectOfType<AudioManager>().PLay("powerup");
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.name.Contains("Steak"))
        {
            PlayerHealth.Health++;
            Destroy(gameObject);
            hints.DisplayHint(gameObject.name);
            FindObjectOfType<AudioManager>().PLay("powerup");
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.name.Contains("Emerald"))
        {
            emeraldCount++;
            Destroy(gameObject);
            collected.Add(gameObject.name);
            hints.DisplayHint(gameObject.name);
            FindObjectOfType<AudioManager>().PLay("powerup");
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.name.Contains("Eye_Of_Ender"))
        {
            eyeCount += 1;
            Destroy(gameObject);
            collected.Add(gameObject.name);
            hints.DisplayHint(gameObject.name);
            FindObjectOfType<AudioManager>().PLay("powerup");
        }
    }
    private void Update()
    {
        if (hadShield && called1)
        {
            player.transform.GetChild(0).gameObject.SetActive(true);
            called1 = false;
        }
        if (hadSword && called2)
        {
            player.transform.GetChild(1).gameObject.SetActive(true);
            called2 = false;
        }
        if (hadBow && called3)
        {
            player.transform.GetChild(2).gameObject.SetActive(true);
            called3 = false;
        }
        if (emeraldCount >= 2 && called4)
        {
            try
            {
                Bubble.gameObject.SetActive(true);
                called4 = false;
            }
            catch (System.Exception) { }
        }
        if (eyeCount == 2 && called5)
        {
            try
            {
                Portal.gameObject.SetActive(true);
                called5 = false;
            }
            catch (System.Exception) { }
        }
    }
    private void Awake()
    {
        try
        {
            if (collected.Count > 0 && called)
            {
                foreach (string item in collected)
                {
                    GameObject GO = GameObject.Find(item);

                    GO.SetActive(false);
                }
                called = false;
            }
        }
        catch { }
        hints = GameObject.FindObjectOfType<Hints>();
    }
}
