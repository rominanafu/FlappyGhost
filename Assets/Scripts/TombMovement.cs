using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Begin movement of a tomb
public class TombMovement : MonoBehaviour
{
    public float impulseForce;

    public float SetImpulseForce {
        set {
            impulseForce = value;
        }
    }

    // Add initial impulse to the tomb
    void Start()
    {
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        r.AddForce(new Vector2(impulseForce, 0), ForceMode2D.Impulse);
    }
}
