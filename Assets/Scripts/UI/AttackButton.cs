using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public GameObject sword;
    public GameObject bow;
    public Animator Animator;
    public void ButtonClick()
    {
        if (sword.gameObject.activeSelf)
        {
            FindObjectOfType<Sword>().Attack();
            Animator.SetTrigger("F");
        }
        if (bow.gameObject.activeSelf)
        {
            FindObjectOfType<Bow>().Shoot();
        }
    }
}
