using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class End : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Endf());
    }
    IEnumerator Endf()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene(0);
    }
}
