using UnityEngine;

public class TheDragon : MonoBehaviour
{
    // Static variables
    public static float dragonHealth = 100f;
    public static bool isDead = false;

    // Instance Variables
    private bool moveRight = false;
    [SerializeField] private float speed;
    [SerializeField] private GameObject sprite;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject firework;
    [SerializeField] private End gameEnd;
    private float lastsht;
    private Player shit;
    [SerializeField] private Animator Animator;
    private AudioManager audioManager = AudioManager.instance;

    private void Awake()
    {
        shit = FindObjectOfType<Player>();
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

        if ((Time.time > lastsht + 3f) && Portal.InEnd) Shoot();
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
        if (collision.gameObject == shit.gameObject) MeeleAttack();
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
        audioManager?.curTrack?.Stop();
        Instantiate(firework, shit.transform.position, Quaternion.identity);
        LevelManager.ui.ShowGameEnd();
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        dragonHealth = Mathf.Max(0f, dragonHealth - damage);
        if (dragonHealth == 0f) Die();
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
