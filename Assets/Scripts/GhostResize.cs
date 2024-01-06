using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Resize ghost sprite to a smaller size
public class GhostResize : MonoBehaviour {

    const float ScaleFactor = 0.45f;

    // Change size of ghost
    void Start() {
        Vector3 newScale = transform.localScale;
        newScale.x *= ScaleFactor;
        newScale.y *= ScaleFactor;
        transform.localScale = newScale;
    }
    
}
