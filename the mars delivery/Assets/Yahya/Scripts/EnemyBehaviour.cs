using System;
using Unity.VisualScripting;
using UnityEngine;

// This script manages the enemy's health. Simple and direct.
public class EnemyBehaviour : MonoBehaviour
{
    private int health = 5;
    [SerializeField] private GameObject Squibble;

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
            Destroy(gameObject);
        }
    }
}