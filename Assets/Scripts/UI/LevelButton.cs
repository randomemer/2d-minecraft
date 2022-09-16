using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    private void Start()
    {
        if (sceneIndex > 1) GetComponent<Button>().interactable = Levls.levels[sceneIndex - 2];
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
