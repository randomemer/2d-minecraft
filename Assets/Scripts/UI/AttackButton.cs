using UnityEngine;

public class AttackButton : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    public void ButtonClick()
    {
        if (player.sword.isActive) player.sword.Attack();
        if (player.bow.isActive) player.bow.Shoot();
    }
}
