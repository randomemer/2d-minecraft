using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    protected bool isMoving = true;
    protected bool isMovingRight = true;
    public float speed;
    public bool usesTurnTag;
    public Transform groundDetection;

    protected virtual void Update()
    {
        Move();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("turn")) changeDirection();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }

    void Move()
    {
        if (!isMoving) return;
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (usesTurnTag) return;

        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 0.5f);
        if (!groundinfo.collider) changeDirection();
    }

    void changeDirection()
    {
        isMovingRight = !isMovingRight;
        float y = (isMovingRight) ? 0 : -180;
        transform.eulerAngles = new Vector3(0, y, 0);
    }
}