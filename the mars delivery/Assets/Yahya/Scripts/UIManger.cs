using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;


public class UIManger : MonoBehaviour
{
    public PlayerManager PlayerManager;
    public Image HealthSlider;
    private float CurrentHealth = 1000;
    private CinemachineImpulseSource s;
    [SerializeField] private AudioClip hitSound;  
    public AudioSource audioSource;

    private void Start()
    {
        s = GetComponent<CinemachineImpulseSource>();
    }
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
        HealthSlider.fillAmount = CurrentHealth / 1000f;
        cameraShakeManger.Instance.cameraShake(s);
        if (audioSource != null && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
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
