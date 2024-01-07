using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Resize ghost sprite to a smaller size
public class GhostSettings : MonoBehaviour {

    const float ScaleFactor = 0.45f;

    // Change size of ghost
    void Start() {
        // Resize
        Vector3 newScale = transform.localScale;
        newScale.x *= ScaleFactor;
        newScale.y *= ScaleFactor;
        transform.localScale = newScale;

        // Initial location
        Vector3 location = new Vector3(Screen.width * (1f/4f), Screen.height/2, 0);
        location = Camera.main.ScreenToWorldPoint(location);
        location.z = 0;
        transform.position = location;
    }
    
}
