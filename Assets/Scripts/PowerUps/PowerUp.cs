using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour
{
    [HideInInspector] public Player player;
    public bool shouldRespawn;
    [HideInInspector] public bool isCollected;
    protected Hints hints;
    [HideInInspector] public UnityEvent collectedEvent;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        hints = FindObjectOfType<Hints>();
    }

    protected virtual bool OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return false;

        FindObjectOfType<AudioManager>()?.PLay("powerup");
        gameObject.SetActive(false);
        isCollected = true;
        collectedEvent.Invoke();
        return true;
    }
}
