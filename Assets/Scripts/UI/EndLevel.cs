using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player") LevelManager.ui.ShowLevelComplete();
    }
}
