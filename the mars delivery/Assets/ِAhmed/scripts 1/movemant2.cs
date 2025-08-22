using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movemant2 : MonoBehaviour
{
    [SerializeField] private float position_x, position_y;
    [SerializeField] private float velocity_x, velocity_y;
    [SerializeField] private float accelaration_x, accelaration_y;
    [SerializeField] private float top_speed, top_accelaration;
    [SerializeField] private float total_speed, scale;
    [SerializeField] private float last_move_direction_x, last_move_direction_y;
    [SerializeField] private bool move_up, move_down, move_right, move_left;
    [SerializeField] private bool facing_right, attack, pick_up;
    [SerializeField] private Animator animator;
    private enum Direction { up, down, right, left };

    // Start is called before the first frame update
    void Start()
    {
        facing_right = true;
        attack = false;
        pick_up = false;
        animator = GetComponent<Animator>();
        position_x = transform.position.x;
        position_y = transform.position.y;
        velocity_x = 0;
        velocity_y = 0;
        accelaration_x = 0;
        accelaration_y = 0;
        top_speed = 0.01f;
        top_accelaration = 0.005f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(position_x, position_y);
        position_x += velocity_x;
        position_y += velocity_y;
        velocity_x += accelaration_x;
        velocity_y += accelaration_y;
        velocity_x = Mathf.Clamp(velocity_x, -1 * top_speed, top_speed);
        velocity_y = Mathf.Clamp(velocity_y, -1 * top_speed, top_speed);
        total_speed = Mathf.Sqrt(velocity_x * velocity_x + velocity_y * velocity_y);
        scale = top_speed / total_speed;
        move_down = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        move_up = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        move_right = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        move_left = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        animator.SetFloat("idle_x", last_move_direction_x);
        animator.SetFloat("idle_y", last_move_direction_y);
        animator.SetFloat("walk_x", velocity_x / top_speed);
        animator.SetFloat("walk_y", velocity_y / top_speed);
        animator.SetFloat("attack_x", last_move_direction_x);
        animator.SetFloat("attack_y", last_move_direction_y);
        animator.SetFloat("magnitude", total_speed / top_speed);

        // <-------------------------------> //

        if (total_speed > top_speed/10) // moving
        {
            last_move_direction_x = velocity_x / top_speed;
            last_move_direction_y = velocity_y / top_speed;
        }

        // <-------------------------------> //

        if (move_right && !move_left)
        {
            accelaration_x = top_accelaration;
        }
        else if (move_left && !move_right)
        {
            accelaration_x = -1 * top_accelaration;
        }
        else
        {
            Stopx();
        }

        // <-------------------------------> //

        if (move_up && !move_down)
        {
            accelaration_y = top_accelaration;
        }
        else if (move_down && !move_up)
        {
            accelaration_y = -1 * top_accelaration;
        }
        else
        {
            Stopy();
        }

        // <-------------------------------> //

        if (Input.GetKey(KeyCode.Space))
        {
            attack = true;
        }
        else
        {
            attack = false;
        }

        // <-------------------------------> //

        if (total_speed > top_speed)
        {
            velocity_x *= scale;
            velocity_y *= scale;
        }

        // <-------------------------------> //

        if (Input.GetKey(KeyCode.E))
        {
            animator.SetBool("pick_up", true);
        }
        else
        {
            animator.SetBool("pick_up", false);
        }

        // <-------------------------------> //

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack", false);
        }
    }
    private void Stopx()
    {
        if (Mathf.Abs(velocity_x) < 0.01f)
        {
            velocity_x = 0;
            accelaration_x = 0;
        }
        else if (velocity_x > 0)
        {
            accelaration_x = -1 * top_accelaration;
        }
        else if (velocity_x < 0)
        {
            accelaration_x = top_accelaration;
        }
    }
    private void Stopy()
    {
        if (Mathf.Abs(velocity_y) < 0.01f)
        {
            velocity_y = 0;
            accelaration_y = 0;
        }
        else if (velocity_y > 0)
        {
            accelaration_y = -1 * top_accelaration;
        }
        else if (velocity_y < 0)
        {
            accelaration_y = top_accelaration;
        }
    }
}
