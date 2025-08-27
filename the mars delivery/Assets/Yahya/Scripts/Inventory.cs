using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public int RawHotDogs, CookedHotDogs, squibbles;

    [Header("UI References")]
    public TMP_Text SquibbleT, RawHotDogsT, CookedHotDogsT;

    public SquibbleSpawner squibbleSpawner;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Subscribe to sceneLoaded event
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        SquibbleT = GameObject.Find("squibbles count")?.GetComponent<TMP_Text>();
        RawHotDogsT = GameObject.Find("RawHotDogsText")?.GetComponent<TMP_Text>();
        CookedHotDogsT = GameObject.Find("CookedHotDogsText")?.GetComponent<TMP_Text>();

        RefreshUI();
    }

    private void OnDestroy()
    {
        // Unsubscribe to avoid errors
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Try to find new UI references each time scene loads
        if (!SquibbleT) SquibbleT = GameObject.Find("SquibbleText")?.GetComponent<TMP_Text>();
        if (!RawHotDogsT) RawHotDogsT = GameObject.Find("RawHotDogsText")?.GetComponent<TMP_Text>();
        if (!CookedHotDogsT) CookedHotDogsT = GameObject.Find("CookedHotDogsText")?.GetComponent<TMP_Text>();

        // Refresh after re-hook
        RefreshUI();
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
        squibbles -= 2;
        RawHotDogs -= 1;
        RefreshUI();
    }

    private void RefreshUI()
    {
        if (SquibbleT) SquibbleT.text = $"{squibbles}";
        if (RawHotDogsT) RawHotDogsT.text = $"{RawHotDogs}";
        if (CookedHotDogsT) CookedHotDogsT.text = $"{CookedHotDogs}";
    }

    public void SellHotDogs()
    {
        if (CookedHotDogs <= 0) return;
        CookedHotDogs--;
        squibbles += 5;
        RefreshUI();
    }
}
