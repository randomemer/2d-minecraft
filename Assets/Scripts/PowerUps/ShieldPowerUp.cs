using UnityEngine;

public class ShieldPowerUp : PowerUp
{
    protected override bool OnTriggerEnter2D(Collider2D collider)
    {
        if (!base.OnTriggerEnter2D(collider)) return false;

        player.shield.Activate();
        Shield.durability = 10;
        hints.DisplayHint("ShieldUP");
        return true;
    }
}