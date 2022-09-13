using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        LevelManager.ResetState();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        LevelManager.ResetState();
    }
}
