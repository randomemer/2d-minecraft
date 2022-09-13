using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private PowerUp[] keys;
    [SerializeField] private GameObject openDoor;
    [SerializeField] private GameObject closeDoor;
    private bool isOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (!isOpen) CheckKeys();
    }

    private void CheckKeys()
    {
        foreach (var item in keys)
        {
            if (!item.isCollected) return;
        }
        isOpen = true;
        openDoor.SetActive(true);
        closeDoor.SetActive(false);
    }
}
