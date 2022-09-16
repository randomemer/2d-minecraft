using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class End : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel;

    private void Awake()
    {
        StartCoroutine(EndGame());
    }

    public IEnumerator EndGame()
    {
        // Show fireworks for a while
        yield return new WaitForSeconds(4f);
        // Show credits for a while
        creditsPanel.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        // Go back to main screen
        SceneManager.LoadScene(0);
    }
}
