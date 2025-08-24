using UnityEngine;

public class CookingStaion : MonoBehaviour
{
    public float cookTime = 3f;
    private bool cooking = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (!cooking && Inventory.Instance.goo >= 2 && Inventory.Instance.water >= 1)
            {
                StartCoroutine(Cook());
            }
        }
    }

    private System.Collections.IEnumerator Cook()
    {
        cooking = true;
        Inventory.Instance.SpendForCooking();
        yield return new WaitForSeconds(cookTime);
        Inventory.Instance.AddDish(1);
        cooking = false;
    }
}
