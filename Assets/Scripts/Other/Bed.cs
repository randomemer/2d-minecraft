using UnityEngine;

public class Bed : MonoBehaviour
{
    public int bedIndex;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && bedIndex > LevelManager.lastBedIndex)
        {
            LevelManager.respawnPoint = gameObject.transform.position;
            LevelManager.lastBedIndex = bedIndex;
        }
    }
}
