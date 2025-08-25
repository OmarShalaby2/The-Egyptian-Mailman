using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "next_scene_town")
        {
            SceneManager.LoadScene("martian_town");
        }
        else if (collision.gameObject.name == "next_scene_crash")
        {
            SceneManager.LoadScene("crash");
        }
    }
}
