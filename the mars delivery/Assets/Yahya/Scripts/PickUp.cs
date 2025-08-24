using UnityEngine;

public class PickUp : MonoBehaviour
{
    public enum ResourceType { SquibblesR, RawHotDogsR, CookedHotDogsR }
    public ResourceType type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.Instance.Add(type, 1);
            Destroy(gameObject);
        }
    }
}
