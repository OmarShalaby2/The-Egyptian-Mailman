using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManger : MonoBehaviour
{
    public PlayerManager PlayerManager;
    public Image HealthSlider;
    private float CurrentHealth = 100;
    //public TextMeshProUGUI Squibbles_Text;
    //public SquibbleSpawner squibbleSpawner;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) TakeDamge(10);
        if (Input.GetKeyDown(KeyCode.E)) HealAmount(10);
        if (CurrentHealth <= 0) Application.LoadLevel(Application.loadedLevel);
    }

    public void TakeDamge(int damage)
    {
        if (HealthSlider.fillAmount <= 0) return;
        CurrentHealth -= damage;
        HealthSlider.fillAmount = CurrentHealth / 100f;
        PlayerManager.Flash();
    }

    public void HealAmount(int heal)
    {
        if (HealthSlider.fillAmount == 1) return;
        CurrentHealth += heal;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, 100);
        HealthSlider.fillAmount = CurrentHealth / 100f;
    }

    // ✅ Now just updates UI text using SquibbleSpawner’s count
    //public void UpdateSquibblesText()
    //{
    //    Squibbles_Text.text = $"Squibbles: {squibbleSpawner.GetSquibbleCount()}";
    //}
}
