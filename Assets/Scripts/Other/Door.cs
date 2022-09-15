using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public UnityEvent keysCollectedEvent = new UnityEvent();
    [SerializeField] private PowerUp[] keys;
    [SerializeField] private GameObject openDoor;
    [SerializeField] private GameObject closeDoor;

    private void Awake()
    {
        foreach (PowerUp key in keys)
        {
            key.collectedEvent.AddListener(CheckKeys);
        }
    }

    private void CheckKeys()
    {
        foreach (var item in keys)
        {
            if (!item.isCollected) return;
        }
        openDoor.SetActive(true);
        closeDoor.SetActive(false);
        keysCollectedEvent.Invoke();
    }
}
