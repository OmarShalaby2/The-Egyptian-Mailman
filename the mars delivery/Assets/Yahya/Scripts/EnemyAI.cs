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
    private Transform PlayerLocation;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
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
        PlayerLocation = playerTransform;
        // نتأكد إن عندنا هدف نطارده
        if (playerTransform != null)
        {
            // السطر ده هو مفتاح الحل:
            // بنعرّف ونحسب متغير الاتجاه "داخل" الدالة نفسها
            // عشان يتحدث كل مرة يتم استدعاء الدالة فيها
            Vector2 direction = (PlayerLocation.position - transform.position).normalized;

            // بنطبق السرعة في الاتجاه الجديد المحدث
            rb.velocity = direction * speed;
        }
    }
}