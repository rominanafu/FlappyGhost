using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Freeze scene and show game over message
public class GameOver : MonoBehaviour {

    [SerializeField]
    GameObject prefabGameOver;

    // Show message of game over
    void GameOverMessage() {
        // Set location of the message
        Vector3 location = new Vector3(Screen.width/2, Screen.height/2, 0);
        location = Camera.main.ScreenToWorldPoint(location);
        location.y += 1f;
        location.z = -1;

        // Show message
        GameObject gameover = Instantiate<GameObject>(prefabGameOver, location, Quaternion.identity);
    }

    // Called when the ghost collides
    void OnCollisionEnter2D(Collision2D collision) {

        // Stop ghost movement
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        // Stop tombs movement
        GameObject tomb = GameObject.FindWithTag("DestroyableObject");
        while (tomb != null) {
            tomb.GetComponent<TombMovement>().StopMovement();
            tomb.tag = "Untagged";
            tomb = GameObject.FindWithTag("DestroyableObject");
        }

        // Stop skulls movement
        GameObject skull = GameObject.FindWithTag("DestroyableSkull");
        while (skull != null) {
            skull.GetComponent<SkullMovement>().StopMovement();
            skull.tag = "Untagged";
            skull = GameObject.FindWithTag("DestroyableSkull");
        }

        GameOverMessage();

    }

}
