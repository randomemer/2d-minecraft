using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidBreath : MonoBehaviour
{
    TheDragon dragon;
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dragon.AcidAttack();
        }
    }
    private void Awake()
    {
        dragon = GameObject.Find("Ender Dragon").GetComponent<TheDragon>();
        Destroy(gameObject, 5f);
    }
}
