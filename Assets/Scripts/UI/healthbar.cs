using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    private Player shit;
    private void Awake()
    {
        shit = FindObjectOfType<Player>();
    }
    private void Update()
    {
        switch (gameObject.name)
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
