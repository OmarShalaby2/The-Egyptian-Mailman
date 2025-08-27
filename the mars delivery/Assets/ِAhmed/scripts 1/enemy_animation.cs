using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_animation : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public EnemyBehaviour enemyBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("health", enemyBehaviour.health);
        animator.SetFloat("magnitude", rb.velocity.magnitude/3f);
        animator.SetFloat("idel_x", rb.velocity.x);
        animator.SetFloat("idel_y", rb.velocity.y);
        animator.SetFloat("run_x", rb.velocity.x);
        animator.SetFloat("run_y", rb.velocity.y);
        animator.SetFloat("hurt_x", rb.velocity.x);
        animator.SetFloat("hurt_y", rb.velocity.y);
        animator.SetFloat("death_x", rb.velocity.x);
        animator.SetFloat("death_y", rb.velocity.y);
        animator.SetFloat("attack_x", rb.velocity.x);
        animator.SetFloat("attack_y", rb.velocity.y);
    }
}
