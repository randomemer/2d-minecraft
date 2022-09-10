using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject Bed3;
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject DragonBar;
    public GameObject PlayerBar;
    public static bool InEnd = false;
    private void Start()
    {
        if (InEnd)
        {
            Cam1.SetActive(false); Cam2.SetActive(true);
            PlayerBar.SetActive(true); DragonBar.SetActive(true);
            FindObjectOfType<AudioManager>().Switch();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = Bed3.transform.position;
            StartCoroutine(Wait(1f));
            InEnd = true;
            FindObjectOfType<AudioManager>().Switch();
        }
    }
    IEnumerator Wait(float x)
    {
        yield return new WaitForSeconds(x);
        Cam1.SetActive(false); Cam2.SetActive(true);
        PlayerBar.SetActive(true);
        DragonBar.SetActive(true);
    }
}
