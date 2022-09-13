using UnityEngine;
using Pathfinding;


public class Phantom : MonoBehaviour
{
    public AIPath aiPath;
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
