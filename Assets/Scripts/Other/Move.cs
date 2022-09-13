using UnityEngine;
public class Move : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        switch (collision.gameObject.name)
        {
            case "Shield":
                Shield.damage();
                break;
            case "Player":
                FindObjectOfType<Player>().Kill();
                break;
            case "Ender Dragon":
                TheDragon.dragonHealth -= 5;
                break;
            default:
                break;
        }

        Destroy(gameObject);
        FindObjectOfType<AudioManager>()?.PLay("arrow");
    }
}
