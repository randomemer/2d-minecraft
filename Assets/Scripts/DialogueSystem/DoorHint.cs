using UnityEngine;

public class DoorHint : MonoBehaviour
{
    [SerializeField] private string hintName;
    private Hints hints;

    private void Awake()
    {
        hints = GameObject.FindObjectOfType<Hints>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") hints.DisplayHint(hintName);
    }
}
