using UnityEngine;

public class TheDragon : MonoBehaviour
{
    bool MoveRight = false;
    public float speed;
    public GameObject player;
    public GameObject sprite;
    public GameObject ball;
    public GameObject firework;
    float lastsht;
    PlayerHealth shit;
    public static int dragonHealth = 100;
    public static bool isDead = false;
    public Animator Animator;
    bool called = true;
    bool called1 = true;
    private void Awake()
    {
        shit = GameObject.Find("Player").GetComponent<PlayerHealth>();
        if (isDead)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
        }
        if ((Time.time > lastsht + 2f) && Portal.InEnd)
        {
            Shoot();
        }
        if (called && dragonHealth <= 0f)
        {
            Die();
            called = false;
            isDead = true;
        }
        if (Portal.InEnd && called1)
        {
            InvokeRepeating("Growl", 0.1f, 7f);
            InvokeRepeating("Flap", 0.1f, 1.5f);
            called1 = false;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("turn"))
        {
            if (MoveRight)
            {
                MoveRight = false;
                sprite.transform.rotation = Quaternion.Euler(0, 0, -28.18f);
            }
            else
            {
                MoveRight = true;
                sprite.transform.Rotate(0, 180, 0);
                sprite.transform.rotation = Quaternion.Euler(0, 180, -28.18f);
            }
        }
        if (collision.gameObject == player)
        {
            MeeleAttack();
        }
    }
    void Shoot()
    {
        Instantiate(ball, gameObject.transform.position, Quaternion.identity);
        lastsht = Time.time;
    }
    public void AcidAttack()
    {
        shit.fightHealth -= 0.25f;
        FindObjectOfType<AudioManager>().PLay("hit");
    }
    void MeeleAttack()
    {
        shit.fightHealth -= 5f;
        Animator.SetTrigger("Hit");
        FindObjectOfType<AudioManager>().PLay("hit");
    }
    void Die()
    {
        FindObjectOfType<AudioManager>().PLay("dragondie");
        FindObjectOfType<AudioManager>().track.Stop();
        Instantiate(firework, player.transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
    void Growl()
    {
        FindObjectOfType<AudioManager>().PLay("dragongrowl");
    }
    void Flap()
    {
        FindObjectOfType<AudioManager>().PLay("wings");
    }

}
