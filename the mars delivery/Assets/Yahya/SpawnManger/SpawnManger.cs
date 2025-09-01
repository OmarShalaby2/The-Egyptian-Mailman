using UnityEngine;
using System.Collections;

// Abdo Coder - SpawnManager v0.1 (Prototype Spawner)
// It does one thing: it spawns one enemy. That's it.
// Don't ask for waves or timers yet.

public class SpawnManager : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject enemyPrefab; // The enemy prefab we created.
    [SerializeField] private Transform[] spawnPoint;   // The empty GameObject that marks the spawn location.
    [SerializeField] private float spawnDelay = 2f; // Delay before spawning the enemy (not used in this simple version).
    [SerializeField] private int maxEnemies = 20;
    [SerializeField] private int currentEnemies = 0;
    private EnemyBehaviour enemyBehaviour;
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
        
        if(currentEnemies < maxEnemies)
        {
            // For testing: Press 'S' to spawn an enemy.
            if (Input.GetKeyDown(KeyCode.F))
            {
                StartCoroutine(WaitAndSpawn());
            }
            //else if (enemyPrefab != null && spawnPoint != null)
            //{
            //    StartCoroutine(WaitAndSpawn());
            //}
            //else
            //{
            //    Debug.LogError("Enemy Prefab or Spawn Point is not assigned in the SpawnManager!");
            //}
        }
    }
    public void decrument_enemies()
    {
        currentEnemies = Mathf.Max(0, currentEnemies - 1);
        Debug.Log("An enemy has been killed." + currentEnemies);

    }
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint[Random.Range(0, 10)].position, Quaternion.identity);
     
        currentEnemies++;
        Debug.Log("An enemy has been spawned." + currentEnemies);
    }
    private IEnumerator WaitAndSpawn()
    {
        yield return new WaitForSeconds(spawnDelay);
        SpawnEnemy();
    }
}
//using UnityEngine;
//using System.Collections;

//public class SpawnManager : MonoBehaviour
//{
//    [Header("Spawner Settings")]
//    [SerializeField] private GameObject enemyPrefab;       // The enemy prefab
//    [SerializeField] private Transform[] spawnPoints;      // All spawn locations
//    [SerializeField] private float spawnDelay = 2f;        // Time between spawns
//    [SerializeField] private int maxEnemies = 20;          // Max enemies allowed at once

//    private int currentEnemyCount = 0;

//    private void Start()
//    {
//        if (enemyPrefab == null || spawnPoints.Length == 0)
//        {
//            Debug.LogError("Enemy Prefab or Spawn Points are not assigned in the SpawnManager!");
//            return;
//        }

//        // Start automatic spawning loop
//        StartCoroutine(SpawnLoop());
//    }

//    private IEnumerator SpawnLoop()
//    {
//        while (true) // endless loop
//        {
//            if (currentEnemyCount < maxEnemies)
//            {
//                SpawnEnemy();
//            }
//            yield return new WaitForSeconds(spawnDelay); // wait before spawning again
//        }
//    }

//    private void SpawnEnemy()
//    {
//        int randomIndex = Random.Range(0, spawnPoints.Length);
//        Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
//        currentEnemyCount++;
//        Debug.Log("Spawned enemy. Total: " + currentEnemyCount);
//    }
//}
