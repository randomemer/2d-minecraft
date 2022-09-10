using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject Door1;
    public GameObject OpenDoor1;
    public GameObject Door2;
    public GameObject OpenDoor2;
    public GameObject Door3;
    public GameObject OpenDoor3;
    public static int keyCount = 0;

    bool call1 = true;
    bool call2 = true;
    bool call3 = true;

    void Update()
    {
        if (keyCount >= 1 && call1)
        {
            Door1.gameObject.SetActive(false);
            OpenDoor1.gameObject.SetActive(true);
            call1 = false;
        }
        if (keyCount >= 2 && call2)
        {
            Door2.gameObject.SetActive(false);
            OpenDoor2.gameObject.SetActive(true);
            call2 = false;
        }
        if (Powerup.emeraldCount >= 2 && call3)
        {
            Door3.gameObject.SetActive(false);
            OpenDoor3.gameObject.SetActive(true);
            call3 = false;
        }
    }
}
