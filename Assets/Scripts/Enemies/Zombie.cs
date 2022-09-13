using UnityEngine;

public class Zombie : EnemyPatrol
{
    private void Start()
    {
        InvokeRepeating("Groan", 4f, 4f);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Player>().Kill();
        }
    }

    void Groan()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
