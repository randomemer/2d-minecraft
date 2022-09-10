using UnityEngine;

public class Bow : MonoBehaviour
{
    public Transform firepoint;
    public GameObject arrowPrefab;
    float lastShot;
    bool allowFire = true;
    public void Shoot()
    {
        if (allowFire)
        {
            Instantiate(arrowPrefab, firepoint.position, firepoint.rotation);
            lastShot = Time.time;
            FindObjectOfType<AudioManager>().PLay("bow");
        }
    }
    void Update()
    {
        if (Time.time > lastShot + 1f)
        {
            allowFire = true;
        }
        else
        {
            allowFire = false;
        }
    }
}
