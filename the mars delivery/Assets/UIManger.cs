using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManger : MonoBehaviour
{
    public PlayerManager PlayerManager;
    public Image HealthSlider;
    float CurrentHealth = 100;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q)) TakeDamge(10);
        if (Input.GetKey(KeyCode.E)) HealAmount(10);
        if (CurrentHealth <= 0) Application.LoadLevel(Application.loadedLevel); //reset game if health == 0
    }
    public void TakeDamge(int damage)
    {
        CurrentHealth = CurrentHealth - damage;
        HealthSlider.fillAmount = CurrentHealth / 100f;
    }
    public void HealAmount(int heal)
    {
        CurrentHealth = CurrentHealth + heal;
        heal = Mathf.Clamp(heal, 0, 100);
        HealthSlider.fillAmount = CurrentHealth / 100f;
    }
   
}
