using UnityEngine;

public class Zombie : EnemyPatrol
{
    private void Start()
    {
        InvokeRepeating("Groan", 4f, 4f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerHealth>().Die();
        }
    }

    void Groan()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
