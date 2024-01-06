using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Begin movement of a bat
public class FlyingBatMovement : MonoBehaviour {

    // Impulse force range
    const float MinImpulseForce = -5f;
    const float MaxImpulseForce = -4f;

    // Add initial impulse to the bat
    void Start() {
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        r.AddForce(new Vector2(Random.Range(MinImpulseForce, MaxImpulseForce), 0f), ForceMode2D.Impulse);
    }

}
