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

    public bool IsBoss = false;
    public GameObject RokketParts;


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
        StartCoroutine(DamageRoutine());
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
            StartCoroutine(DeathRoutine());
        }
    }


    private void DropLoot()
    {
        if (Squibble != null && IsBoss == false) Instantiate(Squibble, transform.position, Quaternion.identity);
        else if (Squibble != null && IsBoss == true)
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(Squibble, transform.position, Quaternion.identity);
            }
            if (RokketParts != null) Instantiate(RokketParts, transform.position, Quaternion.identity);
        }


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
            StartCoroutine(AttackRoutine());
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
    IEnumerator AttackRoutine()
    {
        animator.SetBool("attack", true);
        //enemyAI.enabled = false;
        yield return new WaitForSeconds(1f); // length of your attack anim
        //enemyAI.enabled = true;
        animator.SetBool("attack", false);
    }
    IEnumerator DamageRoutine()
    {
        animator.SetBool("damage", true);
        yield return new WaitForSeconds(1f); // length of your attack anim
        animator.SetBool("damage", false);
    }
    IEnumerator DeathRoutine()
    {
        yield return new WaitForSeconds(1.3f); // length of your attack anim
        Die();
        DropLoot();
    }
}
