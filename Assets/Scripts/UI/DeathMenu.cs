using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameMaster.ResetVar();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        GameMaster.ResetVar();
    }
}
