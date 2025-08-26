using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [Header("Scene Settings")]
    public string sceneToLoad; // The name of the target scene
    public string spawnPointName; // The spawn point name in the next scene

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Save the spawn point name so the next scene knows where to place the player
            PlayerPrefs.SetString("SpawnPoint", spawnPointName);

            // Load the target scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}


