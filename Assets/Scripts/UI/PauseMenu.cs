using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private AudioManager audioManager = AudioManager.instance;

    public void Pause()
    {
        gameObject.SetActive(true);
        audioManager?.PauseAudio();
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        audioManager?.ResumeAudio();
    }

    public void Restart()
    {
        LevelManager.LoadNewScene(LevelManager.sceneIndex, true);
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        LevelManager.LoadNewScene(0, true);
        Time.timeScale = 1f;
    }

}
