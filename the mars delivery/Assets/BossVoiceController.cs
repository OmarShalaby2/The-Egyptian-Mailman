using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVoiceController : MonoBehaviour
{
    // Assign your 3 boss audio clips in the Inspector
    public AudioClip[] voiceLines;

    // Set the delay range between voice lines in the Inspector
    [Header("Timing Settings")]
    [Tooltip("The minimum time to wait after a clip finishes before playing the next one.")]
    public float minDelay = 2.0f;

    [Tooltip("The maximum time to wait after a clip finishes before playing the next one.")]
    public float maxDelay = 5.0f;

    private AudioSource audioSource;

    void Awake()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // Check if there are any voice lines to play
        if (voiceLines.Length > 0)
        {
            // Start the continuous loop of playing voice lines
            StartCoroutine(PlayVoiceLinesRoutine());
        }
    }

    private IEnumerator PlayVoiceLinesRoutine()
    {
        // This 'while (true)' loop will run forever
        while (true)
        {
            // Create a temporary list of clips to play from our main array
            // This allows us to remove clips as we play them, ensuring no repeats in one cycle
            List<AudioClip> linesToPlay = new List<AudioClip>(voiceLines);

            // Loop until all clips in the temporary list have been played
            while (linesToPlay.Count > 0)
            {
                // 1. Pick a random clip from the remaining list
                int randomIndex = Random.Range(0, linesToPlay.Count);
                AudioClip clipToPlay = linesToPlay[randomIndex];

                // 2. Play the chosen clip
                audioSource.PlayOneShot(clipToPlay);

                // 3. Remove the clip from the list so it won't be chosen again in this cycle
                linesToPlay.RemoveAt(randomIndex);

                // 4. Wait for the clip to finish playing, plus a random delay
                float randomDelay = Random.Range(minDelay, maxDelay);
                yield return new WaitForSeconds(clipToPlay.length + randomDelay);
            }

            // After all clips have been played once, the outer 'while (true)' loop
            // will restart, re-populating the list and starting the shuffle process again.
        }
    }
}