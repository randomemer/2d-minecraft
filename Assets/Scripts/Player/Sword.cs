using UnityEngine;

public class Sword : MonoBehaviour
{
    public float radius;
    public LayerMask layer;
    bool CoolDown;
    float CoolDownT;
    void Update()
    {
        if (Time.time > CoolDownT + 1f)
        {
            CoolDown = true;
        }
    }
    public void Attack()
    {
        try
        {
            Collider2D[] results = Physics2D.OverlapCircleAll(gameObject.transform.position, radius, layer);
            if (results[0].gameObject.name == "Ender Dragon" && CoolDown)
            {
                TheDragon.dragonHealth -= 10;
                CoolDownT = Time.time;
                CoolDown = false;
            }
            if (!(results[0].gameObject.name == "Ender Dragon"))
            {
                Destroy(results[0]);
            }
        }
        catch (System.Exception) { }
        FindObjectOfType<AudioManager>().PLay("sword");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, radius);
    }
}
