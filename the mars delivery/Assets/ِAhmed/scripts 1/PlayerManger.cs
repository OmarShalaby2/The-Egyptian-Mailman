using UnityEngine;

// Abdo Coder: Final review on Ahmed/Yahya's movement script.
// It's clean now. And more importantly, it's correct.
public class PlayerManger : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float acceleration = 20f; // Increased acceleration for a snappier feel with Rigidbody

    [Header("Components")]
    [SerializeField] private Animator animator;
    private Rigidbody2D rb; // We NEED the Rigidbody2D

    private Vector2 input;
    private Vector2 lastMoveDirection = Vector2.down;

    private void Start()
    {
        // Get components ONCE.
        rb = GetComponent<Rigidbody2D>();
        if (!animator) animator = GetComponent<Animator>();

        // A quick check to make sure nobody forgot to add the Rigidbody.
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the player. Movement will not work!");
            enabled = false; // Disable the script if the component is missing.
        }
    }

    private void Update()
    {
        // Input is fine in Update. It's responsive.
        HandleInput();
        // Animations that aren't tied to physics can also be here.
        UpdateAnimations();
    }

    private void FixedUpdate()
    {
        // ALL physics-related logic MUST be in FixedUpdate. This is the law.
        MovePlayer();
    }

    private void HandleInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();

        if (input != Vector2.zero)
            lastMoveDirection = input;

        // Animator bools are fine in Update.
        animator.SetBool("attack", Input.GetKey(KeyCode.Space));
        animator.SetBool("pick_up", Input.GetKey(KeyCode.E));
    }

    private void MovePlayer()
    {
        // This is the correct way to do it. We calculate the velocity we WANT...
        Vector2 targetVelocity = input * moveSpeed;

        // ...and then we apply it to the Rigidbody's velocity, using your Lerp for smooth acceleration.
        // This respects collisions, physics layers, and everything else in the engine.
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, acceleration * Time.fixedDeltaTime);
    }

    private void UpdateAnimations()
    {
        // We now use the Rigidbody's velocity to drive animations for perfect sync with movement.
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