using UnityEngine;

public class Skeleton : EnemyPatrol
{
    public Transform firepoint;
    public GameObject arrowPrefab;
    float fireRate = 1.5f;
    float lastshot = 0f;
    bool allowfire;
    Vector2 rotation;

    private void Awake()
    {
        InvokeRepeating("Rattle", 5f, 4f);
    }

    void Shoot()
    {
        Instantiate(arrowPrefab, firepoint.position, firepoint.rotation);
        FindObjectOfType<AudioManager>()?.PLay("bow");
    }

    protected override void Update()
    {
        base.Update();

        rotation = (firepoint.transform.rotation.y == 0f) ? Vector2.right : Vector2.left;
        allowfire = (Time.time > (fireRate + lastshot));

        RaycastHit2D hitinfo = Physics2D.Raycast(firepoint.position, rotation, 5f);
        if ((hitinfo.collider != null) && (hitinfo.collider.gameObject.name == "Player" || hitinfo.collider.gameObject.name == "Shield") && allowfire)
        {
            Shoot();
            lastshot = Time.time;
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.name == "Player")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }

    void Rattle()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
