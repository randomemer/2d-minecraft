using UnityEngine;

public class SteakPowerUp : PowerUp
{
    protected override bool OnTriggerEnter2D(Collider2D collision)
    {
        if (!base.OnTriggerEnter2D(collision)) return false;
        player.OneUp();
        hints.DisplayHint("Steak");
        return true;
    }
}