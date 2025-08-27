using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [Header("Scene Settings")]
    public string sceneToLoad;
    public string spawnPointName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Save for next scene
            PlayerPrefs.SetString("SpawnPoint", spawnPointName);

            // Load scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
