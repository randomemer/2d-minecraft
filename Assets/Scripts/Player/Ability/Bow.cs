using UnityEngine;

public class Bow : PlayerAbility
{
    float lastShot;
    public Transform firepoint;
    public GameObject arrowPrefab;

    public void Shoot()
    {
        if (Time.time < lastShot + 1f) return;
        lastShot = Time.time;
        Instantiate(arrowPrefab, firepoint.position, firepoint.rotation);
        FindObjectOfType<AudioManager>()?.PLay("bow");
    }

    void Update()
    {
        if (gameObject.activeSelf && Input.GetButtonDown("Fire1")) Shoot();
    }
}
