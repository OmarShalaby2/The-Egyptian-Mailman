using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManger : MonoBehaviour
{
    public PlayerManager PlayerManager;
    public Image HealthSlider;
    float CurrentHealth = 100;
    public TextMeshProUGUI Squibbles_Text;
    public SquibbleSpawner squibbleSpawner;



    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q)) TakeDamge(10);
        if (Input.GetKeyDown(KeyCode.E)) HealAmount(10);
        if (CurrentHealth <= 0) Application.LoadLevel(Application.loadedLevel); //reset game if health == 0
    }
    public void TakeDamge(int damage)
    {
        if (HealthSlider.fillAmount <= 0) return;
        CurrentHealth = CurrentHealth - damage;
        HealthSlider.fillAmount = CurrentHealth / 100f;
    }
    public void HealAmount(int heal)
    {
        if (HealthSlider.fillAmount == 1) return;
        CurrentHealth = CurrentHealth + heal;
        heal = Mathf.Clamp(heal, 0, 100);
        HealthSlider.fillAmount = CurrentHealth / 100f;
    }
    public void UpdateSquibblesText(int n)
    {
        Debug.Log("Squibbles Collected: " + PlayerManager.SquibbleAmount);
        Squibbles_Text.text = PlayerManager.SquibbleAmount.ToString();
        squibbleSpawner.SpawnSquibbles();
        squibbleSpawner.SpawnSquibblesInGame();
    }


}
