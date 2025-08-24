using UnityEngine;

public class ServingCounter : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (Inventory.Instance.CookedHotDogs > 0)
            {
                Inventory.Instance.CookedHotDogs--;
                Inventory.Instance.AddSquibbles(5);
            }
        }
    }
}
