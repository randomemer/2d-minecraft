using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Shield shield;
    public Sword sword;
    public Bow bow;
    public Elytra elytra;
    public CharacterMovement characterMovement;

    // Health 
    public static int curHealth = 3;
    public static int maxHealth = 3;
    private int hits = 0;

    public Animator HitAnimator;
    private AudioManager audioManager;
    private LevelManager levelManager;

    // For boss battle with ender dragon
    [HideInInspector] public float fightHealth = 100;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void Start()
    {
        gameObject.transform.position = LevelManager.respawnPoint;
    }

    private void Update()
    {
        if (fightHealth <= 0) Kill();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO : Change to tag instead of object name
        if (collision.gameObject.name == "Stopper for platforms") Kill();
    }

    public void Kill()
    {
        curHealth -= 1;

        if (curHealth == 0)
        {
            Destroy(gameObject);
            LevelManager.ui.ShowGameOverUI();
            audioManager?.Stop();
        }
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        audioManager?.PLay("die");
    }

    public void OneUp()
    {
        curHealth = Mathf.Min(curHealth + 1, maxHealth);
        LevelManager.ui.updateHeartsUI();
    }

    public void TakeHit()
    {
        hits++;

        if (hits >= 3) Kill();

        HitAnimator.SetTrigger("Hit");
        audioManager?.PLay("hit");
    }
}