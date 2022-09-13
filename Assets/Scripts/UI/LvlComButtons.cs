using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlComButtons : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        LevelManager.ResetState();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        LevelManager.ResetState();
    }
}
