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
        yield return new WaitForSeconds(5);
        // Show credits for a while
        creditsPanel.SetActive(true);
        yield return new WaitForSeconds(5);
        // Go back to main screen
        SceneManager.LoadScene(0);
    }
}
