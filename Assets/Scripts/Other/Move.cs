using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Move : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "Shield")
        {
            Shield.damage();
        }
        else if (collision.gameObject.name == "Player")
        {
            PlayerHealth.StaticDie();
        }
        if (collision.gameObject.name == "Ender Dragon")
        {
            TheDragon.dragonHealth -= 5;
        }
        Destroy(gameObject);
        FindObjectOfType<AudioManager>().PLay("arrow");
    }
}
