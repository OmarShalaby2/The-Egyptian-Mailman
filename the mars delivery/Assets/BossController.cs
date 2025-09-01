using UnityEngine;
using UnityEngine.SceneManagement; // Important: This is required to manage scenes.

public class BossController : MonoBehaviour
{
    // You can set the boss's maximum health in the Inspector.
    public int maxHealth = 100;

    // Tracks the boss's current health.
    private int currentHealth;

    // This function runs when the object first comes into existence.
    void Start()
    {
        // Set the boss's health to full when it spawns.
        currentHealth = maxHealth;
    }

    // This is a public function that other scripts (like your player's bullets) can call.
    public void TakeDamage(int damageAmount)
    {
        // Reduce current health by the damage amount.
        currentHealth -= damageAmount;

        Debug.Log("Boss Health: " + currentHealth);

        // Check if the boss has run out of health.
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // This function handles what happens when the boss dies.
    private void Die()
    {
        Debug.Log("Boss has been defeated!");

        // --- Optional: Add any death effects here ---
        // For example, play an explosion particle effect or a death sound.

        // Load the scene named "After boss".
        SceneManager.LoadScene("After boss");
    }
}