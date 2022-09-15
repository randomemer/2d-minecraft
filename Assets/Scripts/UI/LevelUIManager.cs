using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUIManager : MonoBehaviour
{
    [SerializeField] private Animator DeathUIAnimator;
    [SerializeField] private Animator LevelCompleteAnimator;
    private AudioManager audioManager = AudioManager.instance;

    // Hearts UI
    [SerializeField] private Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Start()
    {
        updateHeartsUI();
    }


    public void updateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            Image heart = hearts[i];

            if (i < Player.curHealth) heart.sprite = fullHeart;
            else heart.sprite = emptyHeart;

            heart.enabled = i < Player.maxHealth;
        }
    }

    public void ShowGameOverUI()
    {
        gameObject.SetActive(false);
        DeathUIAnimator.SetTrigger("Trig");
        audioManager?.PauseAudio();
    }

    public void ShowLevelComplete()
    {
        gameObject.SetActive(false);
        LevelCompleteAnimator.SetTrigger("End");
        audioManager?.PauseAudio();
        Levls.levels[LevelManager.sceneIndex - 1] = true;
        Levls.Save();
    }
}