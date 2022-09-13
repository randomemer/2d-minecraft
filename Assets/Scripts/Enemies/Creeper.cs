
using System.Collections;
using UnityEngine;

public class Creeper : EnemyPatrol
{
    //Explode
    public float radius;
    public float explosionDelay;
    public LayerMask layer;
    public GameObject particle;
    public Animator animator;

    protected override void Update()
    {
        base.Update();
        if (isMoving) Check();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, radius);
    }

    void Check()
    {
        Collider2D[] results = Physics2D.OverlapCircleAll(gameObject.transform.position, radius, layer);
        foreach (Collider2D collider in results)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                isMoving = false;
                animator.SetBool("boom", true);
                StartCoroutine(Explode());
            }
        }
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(explosionDelay);

        Instantiate(particle, transform.position, Quaternion.identity);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, radius, layer);
        foreach (Collider2D item in colliders)
        {
            if (item.gameObject.CompareTag("Player")) FindObjectOfType<Player>().Kill();
        }

        FindObjectOfType<AudioManager>()?.PLay("explode");
        Destroy(gameObject);
    }
}
