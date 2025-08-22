using UnityEngine;

// Abdo Coder - EnemyAI v0.1 (The "Just-Chase-It" Script)
// No pathfinding, no raycasting, no thinking. It just moves towards the target.
// Perfect for a one-week prototype.

public class EnemyAI : MonoBehaviour
{
    [Header("AI Settings")]
    [Tooltip("The target the enemy will chase. Assign the player's Transform here.")]
    public Transform playerTransform;
    [Tooltip("How fast the enemy moves.")]
    public float speed = 3f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // This is a backup to find the player if we forget to assign it in the Inspector.
        // It's not the most efficient, but it prevents the game from breaking.
       
    }
    private void Update()
    {
        if (playerTransform == null)
        {
            // Make sure your player GameObject has the "Player" tag.
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
            else
            {
                Debug.LogError("Enemy AI could not find GameObject with 'Player' tag.");
                enabled = false; // Disable the script if there's no player to chase.
            }
        }
    }

    void FixedUpdate()
    {
        // If we have a target, move towards it.
        if (playerTransform != null)
        {
            // 1. Calculate the direction from the enemy to the player.
            Vector2 direction = (playerTransform.position - transform.position).normalized;

            // 2. Apply velocity to the Rigidbody to move the enemy in that direction.
            rb.velocity = direction * speed;
        }
    }
}