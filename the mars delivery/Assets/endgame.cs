using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for changing scenes

public class endgame : MonoBehaviour
{
    // Drag your UI Panel/Canvas Group with "The End" text onto this slot in the Inspector.
    public GameObject endScreenUI;

    // This function is called by Unity when another collider enters this object's trigger zone.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // We check if the object that collided has the tag "Rocket".
        // Make sure your rocket GameObject is tagged correctly!
        if (other.CompareTag("Rocket"))
        {
            Debug.Log("Rocket has hit the end trigger!");

            // Start the end game sequence.
            StartEndSequence();
        }
    }

    private void StartEndSequence()
    {
        // First, make sure the UI exists before trying to enable it.
        if (endScreenUI != null)
        {
            // Enable the end screen UI.
            endScreenUI.SetActive(true);
        }

        // Start the coroutine to wait for 5 seconds before changing the scene.
        StartCoroutine(ReturnToMenuAfterDelay());
    }

    // A Coroutine allows us to add a delay.
    private IEnumerator ReturnToMenuAfterDelay()
    {
        // Wait for 5 seconds.
        yield return new WaitForSeconds(5f);

        // After the wait, load the scene named "main menu".
        // Make sure this scene is added to your Build Settings!
        Debug.Log("Returning to Main Menu...");
        SceneManager.LoadScene("main menu");
    }
}