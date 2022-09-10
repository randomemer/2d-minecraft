using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Slider slider;
    PlayerHealth shit;
    private void Awake()
    {
        shit = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }
    private void Update()
    {
        string name = gameObject.name;
        switch (name)
        {
            case "Durability Bar":
                slider.value = Shield.durability;
                break;
            case "HealthBar":
                slider.value = shit.fightHealth;
                break;
            case "DragonHealth":
                slider.value = TheDragon.dragonHealth;
                break;
            default:
                break;
        }
    }
}
