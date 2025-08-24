using UnityEngine;

public class ServingCounter : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (Inventory.Instance.dishes > 0)
            {
                Inventory.Instance.dishes--;
                Inventory.Instance.AddSquibbles(5);
            }
        }
    }
}
