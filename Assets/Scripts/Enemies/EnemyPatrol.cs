using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    bool isMovingRight = true;
    public Transform groundDetection;

    void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }

    void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 0.5f);
        if (!groundinfo.collider)
        {
            isMovingRight = !isMovingRight;
            float y = (isMovingRight) ? -180 : 0;
            transform.eulerAngles = new Vector3(0, y, 0);
        }

    }
}