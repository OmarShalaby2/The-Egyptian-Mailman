using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Stats")]
    public int maxHealth = 30;
    public int health;

    [Header("Knockback")]
    [SerializeField] private float KnockBackForce = 300f;

    [Header("Loot")]
    [SerializeField] private GameObject Squibble;

    [Header("References")]
    private UIManger Manager;
    public EnemyAI enemyAI;
    public Animator animator;
    public Image healthFill; // drag the green fill Image from Canvas
    [Header("Effects")]
    [SerializeField] private GameObject hitParticlesPrefab;

    private CinemachineImpulseSource s;
    [Header("Audio")]
    [SerializeField] private AudioClip hitSound;  // assign in Inspector
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

        // ✅ Spawn red particles
        if (hitParticlesPrefab != null)
        {
            Instantiate(hitParticlesPrefab, transform.position, Quaternion.identity);
        }

        // ✅ Play hit sound
        if (audioSource != null && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        // ✅ Trigger small screen shake
        cameraShakeManger.Instance.cameraShake(s);

        UpdateHealthBar();

        if (health <= 0)
        {
            Die();
            DropLoot();
        }
    }


    private void DropLoot()
    {
        if (Squibble != null)
            Instantiate(Squibble, transform.position, Quaternion.identity);

        Debug.Log("The Enemy Dropped a Squibble!");
    }

    private void Die()
    {
        Debug.Log("Enemy has been defeated!");
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Manager = FindObjectOfType<UIManger>();
            Manager.TakeDamge(25);

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
            rb.AddForce(direction * force, ForceMode2D.Force);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
