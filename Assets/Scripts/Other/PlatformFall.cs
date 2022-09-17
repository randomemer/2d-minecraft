using System.Collections;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{

    protected Rigidbody2D rb;
    Vector3 pos;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = gameObject.transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Invoke("Fall", 0.3f);
            rb.isKinematic = true;
            StartCoroutine(respawnplatform(pos));
        }
    }
    void Fall()
    {
        rb.isKinematic = false;
    }
    IEnumerator respawnplatform(Vector3 pos)
    {
        yield return new WaitForSeconds(3f);
        rb.isKinematic = true;
        gameObject.transform.position = pos;
    }
}
