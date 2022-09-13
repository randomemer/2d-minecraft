using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private AudioManager audioManager;
    // private bool paused;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }


    public void Pause()
    {
        audioManager?.PauseAudio();
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        // paused = true;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        audioManager?.ResumeAudio();
        // paused = false;
    }
    public void Restart()
    {
        LevelManager.LoadNewScene(SceneManager.GetActiveScene().buildIndex, true);
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    public void MainMenu()
    {
        LevelManager.LoadNewScene(0, true);
        Time.timeScale = 1f;
    }

}
