using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController2D controller2D;
    public float move = 0f;
    public float runspeed;
    public static bool jump = false;
    public Joystick controller;
    public Animator animator;

    private void Awake()
    {
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal") * runspeed;
        if (Input.GetButtonDown("jump")) jump = true;

        /*if (controller.Horizontal >= 0.2f)
        {
            move = runspeed;
        }
        else if (controller.Horizontal <= -0.2f)
        {
            move = -runspeed;
        }
        else
        {
            move = 0f;
        }*/

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
