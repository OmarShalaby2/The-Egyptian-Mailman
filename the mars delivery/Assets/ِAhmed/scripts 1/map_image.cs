//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class map_image : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_image : MonoBehaviour
{
    public RectTransform mapImage;     // The UI map image
    public RectTransform playerIcon;   // The red dot
    public Transform player;           // Your player in world space

    // Your map bounds in world coordinates
    public Vector2 worldMin = new Vector2(-326, -297);
    public Vector2 worldMax = new Vector2(110, 130);

    void Update()
    {
        // Normalize player's position between 0 and 1
        float normalizedX = Mathf.InverseLerp(worldMin.x, worldMax.x, player.position.x);
        float normalizedY = Mathf.InverseLerp(worldMin.y, worldMax.y, player.position.y);

        // Convert normalized position to map UI space
        float mapX = Mathf.Lerp(0, mapImage.rect.width, normalizedX);
        float mapY = Mathf.Lerp(0, mapImage.rect.height, normalizedY);

        // Apply the position to the player dot
        playerIcon.anchoredPosition = new Vector2(mapX, mapY);
    }
}
