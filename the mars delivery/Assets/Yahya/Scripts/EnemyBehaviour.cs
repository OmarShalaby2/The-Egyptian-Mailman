using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


// This script manages the enemy's health. Simple and direct.
public class EnemyBehaviour : MonoBehaviour
{
    public int health = 1;
    [SerializeField] private float KnockBackForce = 300f;
    [SerializeField] private GameObject Squibble;
    private UIManger Manager;
    public EnemyAI enemyAI;

    // This function can be called by other scripts (like the Player's attack)
    // to deal damage to this enemy.
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Die();
            DropLoot();
        }
    }

    private void DropLoot()
    {
        Instantiate(Squibble, gameObject.transform.position, Quaternion.identity);
        Debug.Log($"The Enemy Dropped a Squibble!");
    }

    private void Die()
    {
        // For now, dying just means the enemy disappears.
        Debug.Log("Enemy has been defeated!");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Manager = FindObjectOfType<UIManger>();
            Manager.TakeDamge(25);

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if(rb != null)
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