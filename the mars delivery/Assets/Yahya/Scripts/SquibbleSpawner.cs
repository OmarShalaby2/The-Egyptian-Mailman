using UnityEngine;
using System.Collections; // You can keep this if you want to use coroutines
using UnityEngine.UI;
using TMPro;
public class SquibbleSpawner : MonoBehaviour
{
    int num;
    // The UI prefab you want to instantiate (e.g., a Button, Image, or Text)
    public GameObject SquibbleUIPrefab;

    // A reference to the parent UI element, like the Canvas or a Panel.
    public Transform UIRootParent;

    public GameObject SquibbleInGame;
    private Vector3 SquibbleInGamePosition;

    public GameObject TextDisplay;
   
    public int Amount;


    public void SpawnSquibbles()
    {
        // Check if the prefab and parent are assigned to prevent errors
        if (SquibbleUIPrefab != null && UIRootParent != null)
        {
            // Use a loop to create the specified amount of UI objects
            for (int i = 0; i < Amount; i++)
            {
                // Instantiate the UI prefab and set its parent to the UIRootParent
                GameObject newUIObject = Instantiate(SquibbleUIPrefab, UIRootParent);

                // You can also adjust the position, scale, or other properties here
                // For example, to set the local position to (0,0,0)
                newUIObject.transform.localPosition = Vector3.zero;
            }
        }
    }
    public void SpawnSquibblesInGame()
    {

        float x = Random.Range(0, Screen.width);
        float y = Random.Range(0, Screen.height);
        SquibbleInGamePosition = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 10f));


        // Check if the prefab and parent are assigned to prevent errors
        if (SquibbleInGame != null && SquibbleInGamePosition != null)
        {
            // Use a loop to create the specified amount of UI objects
            for (int i = 0; i < Amount; i++)
            {
                GameObject newUIObject = Instantiate(SquibbleInGame, SquibbleInGamePosition, Quaternion.identity);

                // Change the text in this specific spawned object
               
                num++;
            } 
        }
    }


}

