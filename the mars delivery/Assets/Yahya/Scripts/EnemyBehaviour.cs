using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement; // --- NEW --- Needed for changing scenes

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Stats")]
    public int maxHealth = 30;
    public int health;
    [SerializeField]
    public bool isBoss = false; // --- NEW --- Check this box in the Inspector for the boss

    [Header("Knockback")]
    [SerializeField] private float KnockBackForce = 300f;

    [Header("Loot")]
    [SerializeField] private GameObject Squibble;

    [Header("References")]
    private UIManger Manager;
    public EnemyAI enemyAI;
    public Animator animator;
    public Image healthFill;

    [Header("Effects")]
    [SerializeField] private GameObject hitParticlesPrefab;
    private CinemachineImpulseSource s;

    [Header("Audio")]
    [SerializeField] private AudioClip hitSound;
    public AudioSource audioSource;

    private void Start()
    {
        if (!animator) animator = GetComponent<Animator>();
        health = maxHealth;
        UpdateHealthBar();
        s = GetComponent<CinemachineImpulseSource>();
        audioSource = GetComponent<AudioSource>();
    }

    void UpdateHealthBar()
    {
        if (healthFill != null)
            healthFill.fillAmount = (float)health / maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (hitParticlesPrefab != null)
        {
            Instantiate(hitParticlesPrefab, transform.position, Quaternion.identity);
        }

        if (audioSource != null && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        // Note: The line below will cause an error if you don't have a cameraShakeManger script.
        // I have commented it out. Uncomment it if you have that manager set up.
        // cameraShakeManger.Instance.cameraShake(s);

        UpdateHealthBar();

        if (health <= 0)
        {
            // --- MODIFIED SECTION ---
            Debug.Log("Enemy has been defeated!");
            DropLoot();

            // Now, check if this is the boss
            if (isBoss)
            {
                // If it IS the boss, load the next scene
                Debug.Log("Boss defeated! Loading 'After boss' scene.");
                SceneManager.LoadScene("After boss");
            }
            else
            {
                // If it's a regular enemy, just destroy it
                Destroy(gameObject);
            }
        }
    }

    private void DropLoot()
    {
        if (Squibble != null)
            Instantiate(Squibble, transform.position, Quaternion.identity);

        Debug.Log("The Enemy Dropped a Squibble!");
    }

    // The old Die() method is no longer needed, as its logic is now inside TakeDamage.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Improvement Tip: It's better to assign the UIManger in the Inspector 
            // instead of using FindObjectOfType here.
            PlayerManager player = collision.GetComponent<PlayerManager>();
            if (player != null)
            {
                player.TakeDamage(25); // Damage the player
            }

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 KnockbackDirection = (collision.transform.position - transform.position).normalized;
                StartCoroutine(ApplyKnockback(rb, KnockbackDirection, 0.3f, KnockBackForce));
            }
        }
    }

    IEnumerator ApplyKnockback(Rigidbody2D rb, Vector2 direction, float duration, float force)
    {
        float timer = 0f;
        while (timer < duration)
        {
            if (rb == null) yield break;
            rb.AddForce(direction * force, ForceMode2D.Force);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}