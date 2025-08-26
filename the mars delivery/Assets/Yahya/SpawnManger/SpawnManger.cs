using UnityEngine;

// Abdo Coder - SpawnManager v0.1 (Prototype Spawner)
// It does one thing: it spawns one enemy. That's it.
// Don't ask for waves or timers yet.

public class SpawnManager : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject enemyPrefab; // The enemy prefab we created.
    [SerializeField] private Transform spawnPoint;   // The empty GameObject that marks the spawn location.
    [SerializeField] private float spawnDelay = 2f; // Delay before spawning the enemy (not used in this simple version).
    [SerializeField] private int maxEnemies = 5;
    void Start()
    {
        // Simple check to avoid errors if someone forgot to assign the prefabs.
        if (enemyPrefab != null && spawnPoint != null)
        {
            SpawnEnemy();
        }
        else
        {
            Debug.LogError("Enemy Prefab or Spawn Point is not assigned in the SpawnManager!");
        }
    }
    private void Update()
    {
        // For testing: Press 'S' to spawn an enemy.
        if (Input.GetKeyDown(KeyCode.F))
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        
            
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            Debug.Log("An enemy has been spawned. Let the chase begin.");
            StartCoroutine(WaitAndSpawn());
       
      
    }
    private System.Collections.IEnumerator WaitAndSpawn()
    {
        yield return new WaitForSeconds(spawnDelay);
    }
}