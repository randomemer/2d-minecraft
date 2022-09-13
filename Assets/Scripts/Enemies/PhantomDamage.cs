using UnityEngine;

public class PhantomDamage : MonoBehaviour
{
    private Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.TakeHit();
        }
    }
}
