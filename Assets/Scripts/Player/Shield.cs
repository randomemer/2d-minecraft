using UnityEngine;

public class Shield : MonoBehaviour
{
    public static int durability = 10;
    public GameObject durabilitybar;
    bool called = false;
    void Update()
    {
        if (durability == 0)
        {
            gameObject.SetActive(false);
        }

        if (gameObject.activeSelf && !called)
        {
            durabilitybar.SetActive(true);
            Debug.Log("Shield is active");
            called = true;
        }
        if (gameObject.activeSelf == false && called)
        {
            durabilitybar.SetActive(false);
            Debug.Log("Not Active");
            called = false;
        }
    }
    public static void damage()
    {
        durability -= 1;
    }
}
