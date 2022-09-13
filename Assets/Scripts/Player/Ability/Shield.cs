using UnityEngine;

public class Shield : PlayerAbility
{
    public static int durability = 10;
    public GameObject durabilitybar;

    void Update()
    {
        if (durability == 0) Deactivate();
    }

    override public void Activate()
    {
        base.Activate();
        durabilitybar.SetActive(true);
    }

    override public void Deactivate()
    {
        base.Deactivate();
        durabilitybar.SetActive(false);
    }

    public static void damage()
    {
        durability -= 1;
    }
}
