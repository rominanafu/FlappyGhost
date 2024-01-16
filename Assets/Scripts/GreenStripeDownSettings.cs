using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scale and position of lower green stripe
public class GreenStripeDownSettings : MonoBehaviour {

    void Start() {
        // Scale
        float width = GetComponent<SpriteRenderer>().bounds.size.x;
        float height = GetComponent<SpriteRenderer>().bounds.size.y;
        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        transform.localScale = new Vector3(worldScreenWidth/width, 0.7f, 1);

        // Position
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        transform.position = new Vector3(0, -(worldScreenHeight / 2) - (height / 3), -1);
    }

}
