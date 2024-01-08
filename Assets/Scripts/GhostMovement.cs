using System.Collections;
using System.Collections.Generic;
// using UnityEditor.Callbacks;
using UnityEngine;

// Ghost jumping movement
public class GhostMovement : MonoBehaviour
{
    [SerializeField]
    Sprite GhostMiddle;
    [SerializeField]
    Sprite GhostUp;
    [SerializeField]
    Sprite GhostDown;

    Rigidbody2D rb;
    bool running = true;
    const float JumpingImpulse = 9.81f;

    // Set no gravity in the beginning
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Jump and change eyes direction
    void Update() {
        // Jump
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) {
            if (running) {
                rb.gravityScale = 1;
                rb.AddForce(new Vector2(0, JumpingImpulse), ForceMode2D.Impulse);
            }
        }

        // Look up / middle / down
        if (rb.velocity.y >= 3) {
            GetComponent<SpriteRenderer>().sprite = GhostUp;
        } else if (rb.velocity.y <= -3) {
            GetComponent<SpriteRenderer>().sprite = GhostDown;
        } else {
            GetComponent<SpriteRenderer>().sprite = GhostMiddle;
        }
    }

    // Stop jumping, and disable gravity
    void OnCollisionEnter2D(Collision2D collision) {
        running = false;
        rb.gravityScale = 0;
    }
}
