using UnityEngine.SceneManagement;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject skele;
    void Update()
    {
        Change();
    }

    void Change()
    {
        if (gameObject.transform.position.y < -6)
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                skele.SetActive(true);
            }
        }
        else
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }
    }
}
