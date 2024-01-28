using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

// Exit game when X button is clicked
// or ESC is pressed
public class ExitGame : MonoBehaviour {

    const float ScaleFactor = 0.4f;
    float halfWidth;
    float halfHeight;

    // X button settings
    void Start() {

        // Scale and position X button

        Vector3 newScale = transform.localScale;
        newScale.x *= ScaleFactor;
        newScale.y *= ScaleFactor;
        transform.localScale = newScale;

        halfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        halfHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;

        Vector3 location = new Vector3(Screen.width*(35f/36f), Screen.height*(9f/10f), 0);
        location = Camera.main.ScreenToWorldPoint(location);
        location.x -= halfWidth;
        location.y -= halfHeight;
        location.z = -5;
        transform.position = location;

    }

    void Update() {
            
        // Exit game with ESC
        if (Input.GetKeyDown("escape")) {
            Application.Quit();
            // UnityEditor.EditorApplication.isPlaying = false; // for unity editor
        }

        // Exit game with X button
        if (Input.GetMouseButtonDown(0)) {

            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (mousePosition.x <= transform.position.x + halfWidth) {
                if (mousePosition.x >= transform.position.x - halfWidth) {
                    if (mousePosition.y <= transform.position.y + halfHeight) {
                        if (mousePosition.y >= transform.position.y - halfHeight) {
                            Application.Quit();
                            // UnityEditor.EditorApplication.isPlaying = false; // for unity editor
                        }
                    }
                }
            }

        }

    }

}
