using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [HideInInspector] public Player player;
    public bool shouldRespawn;
    [HideInInspector] public bool isCollected;
    protected Hints hints;

    // other
    public GameObject Bubble;

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
        return true;
    }
    private void Update()
    {
        // if (emeraldCount >= 2 && called4)
        // {
        //     try
        //     {
        //         Bubble.gameObject.SetActive(true);
        //         called4 = false;
        //     }
        //     catch (System.Exception) { }
        // }
    }
}
