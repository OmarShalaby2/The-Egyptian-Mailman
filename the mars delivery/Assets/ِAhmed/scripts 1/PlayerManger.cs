using UnityEngine;

// Abdo Coder: PlayerManager with Combat v0.2
// Added a simple melee attack.
public class PlayerManager : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float acceleration = 20f;

    [Header("Combat Settings")]
    [SerializeField] private Transform attackPoint; // The point where the attack originates.
    [SerializeField] private float attackRange = 0.5f; // The radius of the attack.
    [SerializeField] private LayerMask enemyLayers;    // Which layers to consider as "enemy".

    [Header("Components")]
    [SerializeField] private Animator animator;
    private Rigidbody2D rb;

    private Vector2 input;
    private Vector2 lastMoveDirection = Vector2.down;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!animator) animator = GetComponent<Animator>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found!");
            enabled = false;
        }
    }

    private void Update()
    {
        HandleInput();
        UpdateAnimations();

        // New attack handling in Update for responsiveness
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void HandleInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();

        if (input != Vector2.zero)
            lastMoveDirection = input;

        // We moved the attack input out of here to use GetKeyDown for a single attack per press.
        animator.SetBool("pick_up", Input.GetKey(KeyCode.E));
    }

    private void MovePlayer()
    {
        rb.velocity = Vector2.Lerp(rb.velocity, input * moveSpeed, acceleration * Time.fixedDeltaTime);
    }

    // --- NEW COMBAT FUNCTION ---
    private void Attack()
    {
        // Trigger attack animation
        animator.SetTrigger("attack"); // Use a Trigger for one-shot animations like attacking.

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(1); // Deal 1 damage
            }
        }
    }

    // This is for drawing a visual representation of the attack range in the editor.
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    // --- END OF NEW CODE ---

    private void UpdateAnimations()
    {
        Vector2 currentVelocity = rb.velocity;
        animator.SetFloat("walk_x", currentVelocity.normalized.x);
        animator.SetFloat("walk_y", currentVelocity.normalized.y);
        animator.SetFloat("idle_x", lastMoveDirection.x);
        animator.SetFloat("idle_y", lastMoveDirection.y);
        animator.SetFloat("attack_x", lastMoveDirection.x);
        animator.SetFloat("attack_y", lastMoveDirection.y);
        animator.SetFloat("magnitude", currentVelocity.magnitude / moveSpeed);
    }
}