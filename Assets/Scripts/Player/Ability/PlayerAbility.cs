using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    [HideInInspector] public bool isActive;

    public virtual void Activate()
    {
        gameObject.SetActive(true);
        isActive = true;
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
        isActive = false;
    }
}
