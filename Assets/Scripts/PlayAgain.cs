using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgain : MonoBehaviour {

    [SerializeField]
    GameObject prefabGhost;

    bool gameOver = false;

    public void SetGameOver(bool value) {
        gameOver = value;
    }

    // Update is called once per frame
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
                Camera.main.GetComponent<TombPosSpawner>().SetGameOver(false);
                gameOver = false;
            }
        }
    }

}
