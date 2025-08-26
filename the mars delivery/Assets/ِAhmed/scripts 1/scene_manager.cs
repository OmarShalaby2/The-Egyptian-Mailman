using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class SceneChanger : MonoBehaviour
{
    private static SceneChanger instance;
    public GameObject boundries;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep Player alive
        }
        else
        {
            Destroy(gameObject); // Remove duplicates
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "next_scene_town")
        {
            SceneManager.LoadScene("martian_town");
            StartCoroutine(MovePlayerAfterLoad(new Vector2(-325, 20))); // Town position
        }
        else if (collision.gameObject.name == "next_scene_crash")
        {
            SceneManager.LoadScene("crash");
            StartCoroutine(MovePlayerAfterLoad(new Vector2(10, 5))); // Crash position
        }
        else if (collision.gameObject.name == "next_scene_pole")
        {
            SceneManager.LoadScene("pole");
            StartCoroutine(MovePlayerAfterLoad(new Vector2(0, 0))); // Pole position
        }
    }

    private System.Collections.IEnumerator MovePlayerAfterLoad(Vector2 newPos)
    {
        yield return null; // Wait one frame
        transform.position = newPos;
    }
}




