using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scale, position and change of color of upper stripe
public class StripeUpSettings : MonoBehaviour {

    [SerializeField]
    GameObject prefabGreenStripe;

    GameObject greenStripe = null;

    // Initialize settings of stripe
    void Start() {
        // Scale
        float width = GetComponent<SpriteRenderer>().bounds.size.x;
        float height = GetComponent<SpriteRenderer>().bounds.size.y;
        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        transform.localScale = new Vector3(worldScreenWidth/width, 0.7f, 1);

        // Position
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        transform.position = new Vector3(0, (worldScreenHeight / 2) + (height / 3), 0);
    }

    // Change stripe color
    public void ChangeStripe(bool isBlue) {
        if (isBlue) { // blue
            if (greenStripe != null) {
                Destroy(greenStripe);
                greenStripe = null;
            }
        } else { // green
            if (greenStripe == null) {
                greenStripe = Instantiate<GameObject>(prefabGreenStripe);
            }
        }
    }

}
