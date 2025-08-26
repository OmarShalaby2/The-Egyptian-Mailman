using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CookingStaion : MonoBehaviour
{
    public float cookTime = 3f;
    private bool cooking = false;
    


    private void OnTriggerStay2D(Collider2D other)
    {   
         if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (!cooking && Inventory.Instance.squibbles >= 2 && Inventory.Instance.RawHotDogs >= 1)
            {
                
                StartCoroutine(Cook());
                
                
            }
        }
    }
  



    public System.Collections.IEnumerator Cook()
    {
        cooking = true;
        Inventory.Instance.SpendForCooking();
        yield return new WaitForSeconds(cookTime);
        Inventory.Instance.AddCookedHotDog(1);
        cooking = false;
    }
}
