using UnityEngine;

public class PhantomDamage : MonoBehaviour
{
    public PlayerHealth PlayerHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.Damage();
        }
    }
}
