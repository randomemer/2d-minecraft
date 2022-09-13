using UnityEngine;

public class Fall : MonoBehaviour
{
    public Rigidbody2D rb;
    bool Falling;
    void Start()
    {
        rb.isKinematic = true;
    }
    private void Update()
    {
        if (rb.velocity.y < -0.1f)
        {
            Falling = true;
        }
        else
        {
            Falling = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && Falling)
        {
            FindObjectOfType<PlayerHealth>().Die();
        }
        FindObjectOfType<AudioManager>().PLay("anvil");
    }
}
