using UnityEngine;
using TMPro; // if you use TextMeshPro

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public int RawHotDogs, CookedHotDogs,squibbles;

    [Header("UI References")]
    public TMP_Text SquibbleT, RawHotDogsT, CookedHotDogsT;

    public SquibbleSpawner squibbleSpawner;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    void Start()
    {
        if (!squibbleSpawner) squibbleSpawner = FindObjectOfType<SquibbleSpawner>();
    }

    public void Add(PickUp.ResourceType type, int amount)
    {
        if (type == PickUp.ResourceType.SquibblesR) squibbles += amount;
        if (type == PickUp.ResourceType.RawHotDogsR) RawHotDogs += amount;
        if (type == PickUp.ResourceType.CookedHotDogsR) CookedHotDogs += amount;
        RefreshUI();
    }

    public void AddCookedHotDog(int amount) { CookedHotDogs += amount; RefreshUI(); }
    public void AddSquibbles(int amount) { squibbles += amount; RefreshUI(); }

    public void SpendForCooking()
    {
        squibbles -= 2; RawHotDogs -= 1;
        RefreshUI();
    }

    private void RefreshUI()
    {
         SquibbleT.text = $"{squibbles}";
         RawHotDogsT.text = $"{RawHotDogs}";
         CookedHotDogsT.text = $"{CookedHotDogs}";


    }
   public void SellHotDogs()
    {
        if(CookedHotDogs<=0) return;
        CookedHotDogs--;
        squibbles += 5;
        RefreshUI();
    }
}
