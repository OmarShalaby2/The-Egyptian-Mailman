using UnityEngine;

public class fly_animtion : MonoBehaviour
{
    public Animator animator;
    public GameObject smoke;
    [SerializeField] private GameObject particlesSpawnPoint;

    // --- NEW LINES ---
    public AudioClip flyingSound; // 🔊 Your sound effect file will go here.
    private AudioSource audioSource; // The speaker component on this object.

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // --- NEW LINE ---
        // Get the AudioSource component so we can use it.
        audioSource = GetComponent<AudioSource>();
    }

    public void fly()
    {
        animator.SetTrigger("Fly");

        // --- NEW LINE ---
        // Play the sound effect once.
        if (flyingSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(flyingSound);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            fly(); // This will now also trigger the sound!

            // You can keep spawning smoke here for an instant effect...
            Instantiate(smoke, particlesSpawnPoint.transform.position, Quaternion.identity);
        }
    }

    // ...or call this from an Animation Event for a timed effect.
    public void smokeing()
    {
        Instantiate(smoke, particlesSpawnPoint.transform.position, Quaternion.identity);
    }
}