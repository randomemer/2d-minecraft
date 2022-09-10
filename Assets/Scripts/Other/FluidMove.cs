using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidMove : MonoBehaviour
{
    public CharacterMovement ch;
    public CharacterController2D charCon;
    float originalSpeed = 69.3f;
    public GameObject Player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ch.runspeed = originalSpeed * 0.4f;
            Player.GetComponent<Rigidbody2D>().drag = 50f;
            StartCoroutine(Burn());
        }
    }
    IEnumerator Burn()
    {
        yield return new WaitForSeconds(1.5f);
        PlayerHealth.StaticDie();
    }
}
