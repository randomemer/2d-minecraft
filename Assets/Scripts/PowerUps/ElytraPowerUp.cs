using UnityEngine;

public class ElytraPowerUp : PowerUp
{
    protected override bool OnTriggerEnter2D(Collider2D collision)
    {
        if (!base.OnTriggerEnter2D(collision)) return false;

        player.elytra.Activate();
        hints.DisplayHint("Elytra");

        return true;
    }
}