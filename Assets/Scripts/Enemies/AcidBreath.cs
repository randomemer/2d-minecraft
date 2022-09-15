using UnityEngine;

public class AcidBreath : MonoBehaviour
{
    TheDragon dragon;

    private void Awake()
    {
        dragon = FindObjectOfType<TheDragon>();
        Destroy(gameObject, 5f);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dragon.AcidAttack();
        }
    }
}
