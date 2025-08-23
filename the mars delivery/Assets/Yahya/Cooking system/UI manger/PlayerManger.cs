using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManger : MonoBehaviour
{
       
        public Rigidbody2D rigidBody2d;
        public float Speed;
        public int SquibbleCount = 0;
        public EventBus eventBus;
        void Awake()
{
    eventBus = FindObjectOfType<EventBus>();
    if (eventBus == null)
    {
        Debug.LogError("PlayerManger could not find EventBus in the scene!");
    }
}
    public void AddSquibble(int num)
    {
        SquibbleCount += num;
    }

    
        // Start is called before the first frame update
    void Start()
        {
            transform.position = new Vector2(0, 0);
            rigidBody2d.velocity = new Vector2(0, 0);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            Vector2 movement = new Vector2(horizontalInput, verticalInput);
            movement = movement.normalized * Speed; // Normalize to prevent faster diagonal movement

            rigidBody2d.velocity = movement;
        }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Squibble")
        {
            Destroy(collision.gameObject);
            // gameObject.GetComponent<SquibbleSpawner>().SpawnSquibbles();
            // gameObject.GetComponent<SquibbleSpawner>().SpawnSquibblesInGame();
            AddSquibble(1);
            eventBus.TriggerSpawnSquibble();
        }
       
    }


}
