using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Position and size of background
public class BackgroundSettings : MonoBehaviour {

    [SerializeField]
    Sprite BlueBackground;
    [SerializeField]
    Sprite GreenBackground;

    // Initialize settings of the background
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

    // Change background color
    public void ChangeBackground(bool isBlue) {
        if (isBlue) { // blue
            GetComponent<SpriteRenderer>().sprite = BlueBackground;
        } else { //green
        GetComponent<SpriteRenderer>().sprite = GreenBackground;
        }
    }

}
