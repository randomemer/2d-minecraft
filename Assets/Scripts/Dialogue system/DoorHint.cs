using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHint : MonoBehaviour
{
    public Hints hints;
    private void Awake()
    {
        hints = GameObject.FindObjectOfType<Hints>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            hints.DisplayHint(gameObject.name);
        }
    }
}
