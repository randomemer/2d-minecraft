using UnityEngine;

public class Fall : MonoBehaviour
{
    private AudioManager audioManager;
    private Rigidbody2D rb;
    private bool falling;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    private void Update()
    {
        if (rb.velocity.y < -0.1f) falling = true;
        else falling = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && falling)
        {
            FindObjectOfType<Player>().Kill();
        }
        audioManager?.PLay("anvil");
    }
}
