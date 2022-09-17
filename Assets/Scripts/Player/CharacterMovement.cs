using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController2D controller2D;
    private float move = 0f;
    public float runspeed;
    public static bool jump = false;
    public Joystick controller;
    public Animator animator;

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal") * runspeed;
        if (Input.GetButtonDown("jump")) jump = true;

        if (Mathf.Abs(controller.Horizontal) >= 0.55f) move = Mathf.Sign(controller.Horizontal) * runspeed;
        else if (Mathf.Abs(controller.Horizontal) >= 0.2f) move = runspeed * controller.Horizontal;
        else move = 0f;

        if (Mathf.Abs(move) > 0f) animator.SetBool("Running", true);
        else if (move == 0f) animator.SetBool("Running", false);
    }

    void FixedUpdate()
    {
        controller2D.Move(move * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void Jump()
    {
        jump = true;
    }
}
