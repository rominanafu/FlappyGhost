using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Set initial objects in the scene
public class InitialScene : MonoBehaviour {

    [SerializeField]
    GameObject prefabBackground;
    [SerializeField]
    GameObject prefabGhost;
    [SerializeField]
    GameObject prefabUpStripe;
    [SerializeField]
    GameObject prefabDownStripe;

    // Instantiate objects
    void Start() {
        Instantiate<GameObject>(prefabBackground);
        Instantiate<GameObject>(prefabGhost);
        Instantiate<GameObject>(prefabUpStripe);
        Instantiate<GameObject>(prefabDownStripe);
    }
    
}
