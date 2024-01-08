using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroy previous game and instantiate new ones
public class PlayAgain : MonoBehaviour {

    [SerializeField]
    GameObject prefabGhost;

    bool gameOver = false;

    public void SetGameOver(bool value) {
        gameOver = value;
    }

    // Reset scene
    void Update() {
        if (gameOver) {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) {
                // Destroy all "DestroyableObject"-tagged objects
                GameObject obj = GameObject.FindWithTag("DestroyableObject");
                while (obj != null) {
                    obj.tag = "Untagged";
                    Destroy(obj);
                    obj = GameObject.FindWithTag("DestroyableObject");
                }

                // Instantiate new ghost
                GameObject ghost = Instantiate<GameObject>(prefabGhost);

                // Reset variables
                Camera.main.GetComponent<TombPosSpawner>().SetGameOver(false);
                gameOver = false;

            }
        }
    }

}
