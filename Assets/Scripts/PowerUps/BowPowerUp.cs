using UnityEngine;

public class BowPowerUp : PowerUp
{
    protected override bool OnTriggerEnter2D(Collider2D collider)
    {
        if (!base.OnTriggerEnter2D(collider)) return false;

        player.bow.Activate();
        if (player.sword.isActive) player.sword.Deactivate();
        hints.DisplayHint("BowUP");

        return true;
    }
}