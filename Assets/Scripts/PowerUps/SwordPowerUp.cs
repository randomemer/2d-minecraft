using UnityEngine;

public class SwordPowerUp : PowerUp
{
    protected override bool OnTriggerEnter2D(Collider2D collision)
    {
        if (!base.OnTriggerEnter2D(collision)) return false;

        player.sword.Activate();
        if (player.bow.isActive) player.bow.Deactivate();
        hints.DisplayHint("SwordUP");

        return true;
    }
}