using UnityEngine;

public class TheDragon : MonoBehaviour
{
    bool moveRight = false;
    public float speed;
    public GameObject player;
    public GameObject sprite;
    public GameObject ball;
    public GameObject firework;
    float lastsht;
    Player shit;
    public static int dragonHealth = 100;
    public static bool isDead = false;
    public Animator Animator;
    bool called = true;
    private AudioManager audioManager;

    private void Awake()
    {
        shit = FindObjectOfType<Player>();
        audioManager = FindObjectOfType<AudioManager>();
        if (isDead) Destroy(gameObject);
    }

    private void Start()
    {
        if (Portal.InEnd)
        {
            InvokeRepeating("Growl", 0.1f, 7f);
            InvokeRepeating("Flap", 0.1f, 1.5f);
        }
    }

    void Update()
    {
        if (moveRight) transform.Translate(Time.deltaTime * speed, 0, 0);
        else transform.Translate(-1 * Time.deltaTime * speed, 0, 0);

        if ((Time.time > lastsht + 2f) && Portal.InEnd) Shoot();

        if (called && dragonHealth <= 0f)
        {
            Die();
            called = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("turn"))
        {
            float y = moveRight ? 0 : 180;
            sprite.transform.Rotate(0, y, 0);
            sprite.transform.rotation = Quaternion.Euler(0, y, -28.18f);
            moveRight = !moveRight;
        }
        if (collision.gameObject == player) MeeleAttack();
    }
    void Shoot()
    {
        Instantiate(ball, gameObject.transform.position, Quaternion.identity);
        lastsht = Time.time;
    }
    public void AcidAttack()
    {
        shit.fightHealth -= 0.25f;
        audioManager?.PLay("hit");
    }
    void MeeleAttack()
    {
        shit.fightHealth -= 5f;
        Animator.SetTrigger("Hit");
        audioManager?.PLay("hit");
    }
    void Die()
    {
        isDead = true;
        audioManager?.PLay("dragondie");
        audioManager?.track.Stop();
        Instantiate(firework, player.transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
    void Growl()
    {
        audioManager?.PLay("dragongrowl");
    }
    void Flap()
    {
        audioManager?.PLay("wings");
    }

}
