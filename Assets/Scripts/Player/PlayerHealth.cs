using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static int Health = 3;
    int Hits = 0;
    int numOfHearts = 3;
    //Hearts UI
    public Image[] hearts;
    public Sprite Full_Heart;
    public Sprite Empty_Heart;
    //Lives system
    public Animator DeathUI;
    public Animator Hit;
    public GameObject player;
    //BossBattle
    public float fightHealth = 100;
    bool called = true;
    private void Start()
    {
        player.transform.position = GameMaster.respawnPoint;
    }
    public static void StaticDie()
    {
        PlayerHealth p = new PlayerHealth();
        p.Die();
    }
    public void Die()
    {
        if (Health == 0)
        {
            Destroy(gameObject);
            DeathUI.SetTrigger("Trig");
            FindObjectOfType<AudioManager>()?.Stop();
        }
        else
        {
            Health -= 1;
            FindObjectOfType<AudioManager>()?.PLay("die");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            if (Health == 0)
            {
                Die();
            }
        }

    }
    void Update()
    {
        if (Health > numOfHearts)
        {
            Health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Health)
            {
                hearts[i].sprite = Full_Heart;
            }
            else
            {
                hearts[i].sprite = Empty_Heart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if ((Health == 0) || (Hits >= 3) || (fightHealth <= 0))
        {
            Die();
        }
        if (SceneManager.GetActiveScene().buildIndex == 5 && TheDragon.dragonHealth <= 0f && called)
        {
            Debug.Log("Dead");
            StartCoroutine(FadeOut());
            called = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Stopper for platforms")
        {
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Respawn Point" && (collision.gameObject.transform.position.x > GameMaster.prePoint))
        {
            GameMaster.respawnPoint = collision.transform.position;
        }
    }
    public void Damage()
    {
        Hits++;
        Hit.SetTrigger("Hit");
        FindObjectOfType<AudioManager>().PLay("hit");
    }
    public static IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene(6);
        Debug.Log("Bye");
    }
}
