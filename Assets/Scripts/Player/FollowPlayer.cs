using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float offset;
    Vector3 playerpos;
    public float time;
    private void LateUpdate()
    {
        playerpos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        if (player.transform.rotation.eulerAngles.y == 0)
        {
            playerpos = new Vector3(playerpos.x + offset, playerpos.y, playerpos.z);
        }
        else
        {
            playerpos = new Vector3(playerpos.x - offset, playerpos.y, playerpos.z);
        }
        transform.position = Vector3.Lerp(transform.position, playerpos, time * Time.deltaTime);
    }
}
