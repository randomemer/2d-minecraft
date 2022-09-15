using UnityEngine;

public class Villager : MonoBehaviour
{
    public GameObject demandBubble;
    public GameObject sucessBubble;

    public void CollectEmeralds()
    {
        demandBubble?.SetActive(false);
        sucessBubble?.SetActive(true);
    }

}
