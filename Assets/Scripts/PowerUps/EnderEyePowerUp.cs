using UnityEngine;

public class EnderEyePowerUp : PowerUp
{
    private Portal portal;

    private void Awake()
    {
        portal = FindObjectOfType<Portal>(true);
    }

    protected override bool OnTriggerEnter2D(Collider2D collision)
    {
        if (!base.OnTriggerEnter2D(collision)) return false;
        portal.CheckEnderEyes();
        return true;
    }
}