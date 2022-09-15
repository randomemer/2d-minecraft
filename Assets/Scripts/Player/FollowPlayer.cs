using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float offset;
    public float time;
    private void LateUpdate()
    {
        Vector3 position = new Vector3(LevelManager.player.transform.position.x, transform.position.y, transform.position.z);
        position.x += (LevelManager.player.transform.rotation.eulerAngles.y == 0) ? offset : -offset;
        transform.position = Vector3.Lerp(transform.position, position, time * Time.deltaTime);
    }
}
