using UnityEngine;
using TMPro;

public class SquibbleSpawner : MonoBehaviour
{
    public GameObject SquibbleUIPrefab;
    public GameObject HotDogUIPrefab;
    public Transform UIRootParent;
    public GameObject SquibbleInGame;

    public int Amount = 1;

    public TMP_Text squibbleText;
    public TMP_Text hotdogText;

    private int squibbleCount = 0;
    private int hotdogCount = 0;

    //public void SpawnSquibbles()
    //{
    //    if (SquibbleUIPrefab != null && UIRootParent != null)
    //    {
    //        for (int i = 0; i < Amount; i++)
    //        {
    //            Instantiate(SquibbleUIPrefab, UIRootParent);
    //            squibbleCount++;
    //        }
    //        UpdateUI();
    //    }
    //}

    //public void SpawnHotDog()
    //{
    //    if (HotDogUIPrefab != null && UIRootParent != null)
    //    {
    //        for (int i = 0; i < Amount; i++)
    //        {
    //            Instantiate(HotDogUIPrefab, UIRootParent);
    //            hotdogCount++;
    //        }
    //        UpdateUI();
    //    }
    //}

    //public void SpawnSquibblesInGame()
    //{
    //    float x = Random.Range(0, Screen.width);
    //    float y = Random.Range(0, Screen.height);
    //    Vector3 spawnPos = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 10f));

    //    if (SquibbleInGame != null)
    //    {
    //        for (int i = 0; i < Amount; i++)
    //        {
    //            Instantiate(SquibbleInGame, spawnPos, Quaternion.identity);
    //            squibbleCount++;
    //        }
    //        UpdateUI();
    //    }
    //}

    public bool SpendSquibble(int amount)
    {
        if (squibbleCount >= amount)
        {
            squibbleCount -= amount;
            RemoveUIIcons(amount, SquibbleUIPrefab);
            //UpdateUI();
            return true;
        }
        return false;
    }

    public bool SpendHotDog(int amount)
    {
        if (hotdogCount >= amount)
        {
            hotdogCount -= amount;
            RemoveUIIcons(amount, HotDogUIPrefab);
            //UpdateUI();
            return true;
        }
        return false;
    }

    private void RemoveUIIcons(int amount, GameObject prefabType)
    {
        int removed = 0;
        for (int i = 0; i < UIRootParent.childCount && removed < amount; i++)
        {
            GameObject child = UIRootParent.GetChild(i).gameObject;
            if (child.name.Contains(prefabType.name))
            {
                Destroy(child);
                removed++;
            }
        }
    }

    //private void UpdateUI()
    //{
    //    if (squibbleText != null)
    //        squibbleText.text = $"Squibbles: {squibbleCount}";
    //    if (hotdogText != null)
    //        hotdogText.text = $"HotDogs: {hotdogCount}";
    //}

    //// ✅ Expose counts so UIManager can read
    //public int GetSquibbleCount() => squibbleCount;
    //public int GetHotDogCount() => hotdogCount;
}
