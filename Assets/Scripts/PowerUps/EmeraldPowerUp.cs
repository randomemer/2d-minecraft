using UnityEngine;

public class EmeraldPowerUp : PowerUp
{
    protected override bool OnTriggerEnter2D(Collider2D collision)
    {
        if (!base.OnTriggerEnter2D(collision)) return false;
        hints.DisplayHint("Emerald");
        return true;
    }
}