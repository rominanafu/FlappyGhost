using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move skull up and down
public class SkullMovement : MonoBehaviour {

    [SerializeField]
    GameObject prefabTomb07;
    [SerializeField]
    GameObject prefabStripe;

    // Impulse force for x and y
    public float impulseForceX;
    float impulseForceY;

    // Range of impulse force in y axis
    const float MinImpulseForce = 2.5f;
    const float MaxImpulseForce = 3.5f;

    // Limits of skull in y, to avoid collisions with tombs
    float upperLimit;
    float lowerLimit;

    // Direction of skull
    bool upwards;

    Rigidbody2D r;
    float stripeSize;

    public float SetImpulseForce {
        set {
            impulseForceX = value;
        }
    }

    // Begin upward movement
    void Start() {
        impulseForceY = Random.Range(MinImpulseForce, MaxImpulseForce);
        stripeSize = prefabStripe.GetComponent<SpriteRenderer>().bounds.size.y * 0.7f / 6;

        r = GetComponent<Rigidbody2D>();
        r.AddForce(new Vector2(impulseForceX, impulseForceY), ForceMode2D.Impulse);
        upperLimit = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        upperLimit -= prefabTomb07.GetComponent<SpriteRenderer>().bounds.size.y; // tomb 7's height
        upperLimit -= GetComponent<SpriteRenderer>().bounds.size.y / 4; // skull's height / 4
        upperLimit -= stripeSize;
        upwards = true;
    }

    // Freeze skull on its position
    public void StopMovement() {
        r.constraints = RigidbodyConstraints2D.FreezePosition;
        r.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Change direction when limit is reached
    void Update() {

        if (upwards) {

            Vector3 location = transform.position;
            if (location.y >= upperLimit) {
                r.AddForce(new Vector2(0, impulseForceY * -2), ForceMode2D.Impulse);
                upwards = false;
                lowerLimit = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
                lowerLimit += prefabTomb07.GetComponent<SpriteRenderer>().bounds.size.y;
                lowerLimit += GetComponent<SpriteRenderer>().bounds.size.y / 4;
                lowerLimit += stripeSize;
            }

        } else {

            Vector3 location = transform.position;
            if (location.y <= lowerLimit) {
                r.AddForce(new Vector2(0, impulseForceY * 2), ForceMode2D.Impulse);
                upwards = true;
                upperLimit = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
                upperLimit -= prefabTomb07.GetComponent<SpriteRenderer>().bounds.size.y;
                upperLimit -= GetComponent<SpriteRenderer>().bounds.size.y / 4;
                upperLimit -= stripeSize;
            }

        }

    }

}
