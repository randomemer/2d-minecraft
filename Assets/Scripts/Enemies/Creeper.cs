
using System.Collections;
using UnityEngine;

public class Creeper : MonoBehaviour
{
    //Patrol Platform
    bool movingRight = false;
    public Transform groundDetection;
    //Explode
    public float radius;
    public float explosionDelay;
    public LayerMask layer;
    bool moving = true;
    public GameObject particle;
    public Animator animator;
    void Start()
    {
        
    }

    void Update()
    {
        if (moving)
        {
            Move();
            Check();
        }
    }

    void Move()
    {
        transform.Translate(Vector2.left * 2f * Time.deltaTime);
        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 0.5f);
        if (groundinfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
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
                moving = false;
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
            if (item.gameObject.CompareTag("Player"))
            {
                FindObjectOfType<PlayerHealth>().Die();
            }
        }
        FindObjectOfType<AudioManager>().PLay("explode");
        Destroy(gameObject);
    }
}
