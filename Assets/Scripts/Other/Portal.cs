using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Portal : MonoBehaviour
{
    public GameObject Bed3;
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject DragonBar;
    public GameObject PlayerBar;
    [SerializeField] private EnderEyePowerUp[] enderEyes;
    private AudioManager audioManager;
    private List<GameObject> children = new List<GameObject>();
    public static bool InEnd = false;
    private bool hasCollectedAllEyes = false;

    private void Awake()
    {
        enderEyes = FindObjectsOfType<EnderEyePowerUp>(true);
        audioManager = FindObjectOfType<AudioManager>(true);
        foreach (Transform item in transform) children.Add(item.gameObject);
        if (InEnd) SwitchToEnd();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasCollectedAllEyes && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = Bed3.transform.position;
            InEnd = true;
            StartCoroutine(Wait(1f));
        }
    }
    IEnumerator Wait(float x)
    {
        yield return new WaitForSeconds(x);
        SwitchToEnd();
    }

    private void SwitchToEnd()
    {
        Cam1.SetActive(false);
        Cam2.SetActive(true);
        PlayerBar.SetActive(true);
        DragonBar.SetActive(true);
        audioManager?.Switch();
    }

    public void CheckEnderEyes()
    {
        for (int i = 0; i < enderEyes.Length; i++)
        {
            if (!enderEyes[i].isCollected) return;
        }
        hasCollectedAllEyes = true;
        foreach (var item in children) item.SetActive(true);
    }
}
