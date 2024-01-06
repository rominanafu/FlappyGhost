using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Begin movement of a tomb
public class TombMovement : MonoBehaviour
{
    public float impulseForce;
    Rigidbody2D r;

    public float SetImpulseForce {
        set {
            impulseForce = value;
        }
    }

    // Add initial impulse to the tomb
    void Start()
    {
        r = GetComponent<Rigidbody2D>();
        r.AddForce(new Vector2(impulseForce, 0), ForceMode2D.Impulse);
    }

    // Freeze tomb on its position
    public void StopMovement() {
        r.constraints = RigidbodyConstraints2D.FreezePosition;
        r.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
