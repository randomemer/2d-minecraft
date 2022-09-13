using UnityEngine;

public class Sword : PlayerAbility
{
    private float lastUsedTime;
    public float radius;
    public LayerMask layer;
    private AudioManager audioManager;
    private Animator swordAnimator;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        swordAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (gameObject.activeSelf && Input.GetButtonDown("Fire1")) Attack();
    }

    public void Attack()
    {
        if (Time.time < lastUsedTime + 1f) return;

        lastUsedTime = Time.time;
        swordAnimator.SetTrigger("F");
        audioManager?.PLay("sword");

        Collider2D[] results = Physics2D.OverlapCircleAll(gameObject.transform.position, radius, layer);
        if (results.Length == 0) return;

        if (results[0].gameObject.name == "Ender Dragon") TheDragon.dragonHealth -= 10;
        else Destroy(results[0]);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, radius);
    }
}
