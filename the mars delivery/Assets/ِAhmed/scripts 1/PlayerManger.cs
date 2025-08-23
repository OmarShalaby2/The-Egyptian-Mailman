using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float acceleration = 25f;

    [Header("Combat")]
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] LayerMask enemyLayers;

    [Header("Components (on Visual child)")]
     Animator animator;
     SpriteRenderer sprite;
    [Header("health")]
    [SerializeField] float Health;
    Rigidbody2D rb;
    Vector2 input;
    Vector2 lastDir = Vector2.down;
    public int SquibbleAmount;
    public UIManger uimanger;




    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!animator) animator = GetComponentInChildren<Animator>();
        if (!sprite) sprite = GetComponentInChildren<SpriteRenderer>();
        if (!rb) { Debug.LogError("Missing Rigidbody2D on root"); enabled = false; }
        if (!uimanger) uimanger = GetComponentInChildren<UIManger>();
    }

    void Update()
    {
        ReadInput();
     
        UpdateAttackPoint();
        UpdateAnimator();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoAttack();
            
        }
    }

    void FixedUpdate()
    {
        // Smooth acceleration; switch to rb.velocity = input * moveSpeed for snappier controls
        rb.velocity = Vector2.Lerp(rb.velocity, input * moveSpeed, acceleration * Time.fixedDeltaTime);
    }

    void ReadInput()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (input.sqrMagnitude > 0.0001f)
            lastDir = input.normalized;
    }

    
    void UpdateAttackPoint()
    {
        if (!attackPoint) return;

        if (input.sqrMagnitude > 0.0001f)
        {
            // Lock to dominant axis (clean 4-direction attacks)
            Vector2 d = Dominant(lastDir);
            attackPoint.localPosition = d * 0.5f;
        }
    }

    static Vector2 Dominant(Vector2 v)
    {
        return Mathf.Abs(v.x) >= Mathf.Abs(v.y)
            ? new Vector2(Mathf.Sign(v.x), 0f)
            : new Vector2(0f, Mathf.Sign(v.y));
    }

    void DoAttack()
    {
        animator?.SetTrigger("attack");

        if (!attackPoint) return;
        foreach (var hit in Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers))
        {
            hit.GetComponent<EnemyHealth>()?.TakeDamage(1);
        }
       
    }

    // Call this via an Animation Event at the last frame of the attack animation
    public void EndAttack()
    {
        animator?.ResetTrigger("attack");
    }

    void UpdateAnimator()
    {
        if (!animator) return;

        Vector2 vel = rb.velocity;
        Vector2 nvel = vel.sqrMagnitude > 0.001f ? vel.normalized : Vector2.zero;

        // Update last direction only if we're moving
        if (nvel != Vector2.zero)
        {
            lastDir = nvel;
        }

        animator.SetFloat("walk_x", nvel.x);
        animator.SetFloat("walk_y", nvel.y);

        animator.SetFloat("idle_x", lastDir.x);
        animator.SetFloat("idle_y", lastDir.y);
        animator.SetFloat("attack_x", lastDir.x);
        animator.SetFloat("attack_y", lastDir.y);

        animator.SetFloat("magnitude", vel.magnitude / Mathf.Max(0.0001f, moveSpeed));
    }


    void OnDrawGizmosSelected()
    {
        if (attackPoint) Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collectables"))
        {
            Destroy(collision.gameObject);
            Debug.Log("squibble Added!");
            SquibbleAmount++;
            uimanger.UpdateSquibblesText(SquibbleAmount);
        }
    }


}
