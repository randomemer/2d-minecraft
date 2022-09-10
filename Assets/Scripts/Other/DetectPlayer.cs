using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            rb.isKinematic = false;
        }
    }
}
