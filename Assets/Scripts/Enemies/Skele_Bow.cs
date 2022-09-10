using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skele_Bow : MonoBehaviour
{
    public Transform firepoint;
    public GameObject arrowPrefab;

    float fireRate = 1.5f;
    float lastshot = 0f;
    bool allowfire;
    Vector2 rotation;

    private void Awake()
    {
        InvokeRepeating("Rattle", 3f, 4f);
    }
    void Shoot()
    { 
        Instantiate(arrowPrefab, firepoint.position, firepoint.rotation);
        FindObjectOfType<AudioManager>().PLay("bow");
    }
    void Update()
    {
        if (firepoint.transform.rotation.y == 0f)
        {
            rotation = Vector2.right;
        }
        else
        {
            rotation = Vector2.left;
        }

        if (Time.time < fireRate + lastshot)
        {
            allowfire = false;
        }
        else 
        {
            allowfire = true;
        }

        try
        {
            RaycastHit2D hitinfo = Physics2D.Raycast(firepoint.position, rotation, 5f);

            if ((hitinfo.collider.gameObject.name == "Player" || hitinfo.collider.gameObject.name == "Shield") && allowfire)
            {
                Shoot();
                lastshot = Time.time;
            }
        }
        catch (System.Exception)
        {
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
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
