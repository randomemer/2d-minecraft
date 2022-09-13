using System.Collections;
using UnityEngine;

public class FluidMove : MonoBehaviour
{
    private float originalSpeed = 69.3f;
    private Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.characterMovement.runspeed = originalSpeed * 0.4f;
            player.GetComponent<Rigidbody2D>().drag = 50f;
            StartCoroutine(Burn());
        }
    }
    IEnumerator Burn()
    {
        yield return new WaitForSeconds(1.5f);
        player.Kill();
    }
}
