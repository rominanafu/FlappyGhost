using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Set position in the middle
        transform.position = new Vector3(0, 0, 2);
        
        // Set size equal to screen
        float width = GetComponent<SpriteRenderer>().bounds.size.x;
        float height = GetComponent<SpriteRenderer>().bounds.size.y;
        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        transform.localScale = new Vector3(worldScreenWidth/width + 0.1f, worldScreenHeight/height, 1);
    }

}
