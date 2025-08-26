using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_spawner : MonoBehaviour
{
    private void Start()
    {
        string spawnPointName = PlayerPrefs.GetString("SpawnPoint", "");

        if (!string.IsNullOrEmpty(spawnPointName))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject spawnPoint = GameObject.Find(spawnPointName);

            if (player != null && spawnPoint != null)
            {
                player.transform.position = spawnPoint.transform.position;
            }
        }
    }
}



