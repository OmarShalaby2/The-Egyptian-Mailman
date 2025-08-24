using UnityEngine;
using TMPro; // if you use TextMeshPro

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public int goo, water, spice, dishes, squibbles;

    [Header("UI References")]
    public TMP_Text gooText, waterText, spiceText, dishText, squibbleText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void Add(PickUp.ResourceType type, int amount)
    {
        if (type == PickUp.ResourceType.Goo) goo += amount;
        if (type == PickUp.ResourceType.Water) water += amount;
        if (type == PickUp.ResourceType.Spice) spice += amount;
        RefreshUI();
    }

    public void AddDish(int amount) { dishes += amount; RefreshUI(); }
    public void AddSquibbles(int amount) { squibbles += amount; RefreshUI(); }

    public void SpendForCooking()
    {
        goo -= 2; water -= 1; // like GooSoup recipe
        RefreshUI();
    }

    private void RefreshUI()
    {
        gooText.text = "Goo: " + goo;
        waterText.text = "Water: " + water;
        spiceText.text = "Spice: " + spice;
        dishText.text = "Dishes: " + dishes;
        squibbleText.text = "💚 " + squibbles;
    }
}
