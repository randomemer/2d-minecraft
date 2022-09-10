using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie1Patrol : MonoBehaviour
{

    bool isMovingRight;
    public float speed;
    public GameObject player;

    private void Awake()
    {
        InvokeRepeating("Groan", 5f, 4f);
    }

    void Update()
    {
        transform.Translate(Time.deltaTime * speed, 0, 0);
        if (isMovingRight)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("turn"))
        {
            isMovingRight = !isMovingRight;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // PlayerHealth.StaticDie();
            FindObjectOfType<PlayerHealth>().Die();
        }
    }

    void Groan()
    {
        if (gameObject.name.Contains("Skeleton"))
        {
            FindObjectOfType<AudioManager>().PLay("skeleton");
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
