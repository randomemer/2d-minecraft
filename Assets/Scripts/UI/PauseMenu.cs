using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool Paused;
    public void Pause()
    {
        FindObjectOfType<AudioManager>().PauseAudio();
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        Paused = true;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        FindObjectOfType<AudioManager>().ResumeAudio();
        Paused = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        GameMaster.ResetVar();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        GameMaster.ResetVar();
    }

}
