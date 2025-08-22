using UnityEngine;

// This script manages the enemy's health. Simple and direct.
public class EnemyHealth : MonoBehaviour
{
    public int health = 1;

    // This function can be called by other scripts (like the Player's attack)
    // to deal damage to this enemy.
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // For now, dying just means the enemy disappears.
        Debug.Log("Enemy has been defeated!");
        Destroy(gameObject);
    }
}