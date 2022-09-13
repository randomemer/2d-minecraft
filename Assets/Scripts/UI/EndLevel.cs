using UnityEngine;
using UnityEngine.SceneManagement;
public class EndLevel : MonoBehaviour
{
    public GameObject GameUI;
    public Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameUI.SetActive(false);
            animator.SetTrigger("End");
            FindObjectOfType<AudioManager>()?.PauseAudio();
            Levls.levels[SceneManager.GetActiveScene().buildIndex - 1] = true;
            Levls.Save();
        }
    }
}
