using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Show score record
public class ScoreBoxSettings : MonoBehaviour {

    [SerializeField]
    GameObject prefabCanvasCurrScore;
    [SerializeField]
    GameObject prefabCanvasMaxScore;

    [SerializeField]
    Sprite BlueBox;
    [SerializeField]
    Sprite GreenBox;

    // Set the scores box and the scores on top of it
    void Start() {
        
        // Scale
        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        float newWidth = worldScreenWidth/8;
        float newHeight = worldScreenHeight/4;
        float width = GetComponent<SpriteRenderer>().bounds.size.x;
        float height = GetComponent<SpriteRenderer>().bounds.size.y;
        Vector3 newScale = new Vector3(newWidth/width, newHeight/height, 1);
        transform.localScale = newScale;

        // Set location
        Vector3 location = new Vector3(Screen.width/100, Screen.height * (14f/15f), 0);
        location = Camera.main.ScreenToWorldPoint(location);
        location.x += GetComponent<SpriteRenderer>().bounds.size.x / 2;
        location.y -= GetComponent<SpriteRenderer>().bounds.size.y / 2;
        location.z = -5;
        transform.position = location;

        // Instantiate scores
        Instantiate<GameObject>(prefabCanvasCurrScore);
        Instantiate<GameObject>(prefabCanvasMaxScore);

    }

    // Change box color
    public void ChangeBox(bool isBlue) {
        if (isBlue) { // blue
            GetComponent<SpriteRenderer>().sprite = BlueBox;
        } else { //green
        GetComponent<SpriteRenderer>().sprite = GreenBox;
        }
    }

}
