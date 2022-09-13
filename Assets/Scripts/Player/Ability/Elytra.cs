using UnityEngine;

public class Elytra : PlayerAbility
{
    public CharacterController2D characterController;

    override public void Activate()
    {
        base.Activate();
        characterController.Fly();
    }
}