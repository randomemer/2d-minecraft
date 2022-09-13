using UnityEngine;

public class FireBall : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 position;
    public GameObject particle;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        position = GameObject.Find("Player").gameObject.transform.position;
        rb.gravityScale = 0f;
        rb.velocity = (position - transform.position).normalized * 10f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Ender Dragon")
        {
            Destroy(gameObject);
            Instantiate(particle, gameObject.transform.position, Quaternion.identity);
        }
    }
}
