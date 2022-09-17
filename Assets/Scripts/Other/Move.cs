using UnityEngine;
using System.Collections.Generic;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float hitRadius;
    private Collider2D arrowCollider;
    private int hitCount = 0;

    private void Awake()
    {
        arrowCollider = GetComponent<Collider2D>();
    }

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (hitCount > 0) return;

        hitCount += 1;
        Destroy(gameObject);
        AudioManager.instance?.PLay("arrow");

        if (collider2D.gameObject.CompareTag("Enemy")) Destroy(collider2D.gameObject);


        Vector3 arrowTip = arrowCollider.ClosestPoint(collider2D.bounds.center);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(arrowTip, hitRadius);
        Dictionary<string, Collider2D> colliderMap = new Dictionary<string, Collider2D>();
        foreach (Collider2D collider in colliders) colliderMap[collider.gameObject.name] = collider;

        if (colliderMap.ContainsKey("Player") && !colliderMap.ContainsKey("Shield"))
        {
            colliderMap["Player"].gameObject.GetComponent<Player>().Kill();
        }
        else if (colliderMap.ContainsKey("Shield")) Shield.damage();
        else if (colliderMap.ContainsKey("Ender Dragon"))
        {
            colliderMap["Ender Dragon"].gameObject.GetComponent<TheDragon>().TakeDamage(5f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(GetComponent<Collider2D>().bounds.center, hitRadius);
    }
}
