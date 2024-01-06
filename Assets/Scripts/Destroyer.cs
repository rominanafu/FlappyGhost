using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroys a DestroyableBat/DestroyableObject/DestroyableSkull
// tagged object when it is out of the window.

public class Destroyer : MonoBehaviour {

    Vector3 position;
    float posIniX;

    float halfObjWidth;
    float halfBatWidth;
    float halfSkullWidth;

    // Destroy tombs, bats and skulls that get out of screen view
    void Update() {

        // Determine the x position where objects get out of the window
        Vector3 location = new Vector3(0, 0, 0);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        posIniX = worldLocation.x;

        // Find objects
        GameObject obj = GameObject.FindWithTag("DestroyableObject");
        GameObject bat = GameObject.FindWithTag("DestroyableBat");
        GameObject skull = GameObject.FindWithTag("DestroyableSkull");

        // Destroy objects
        if (obj != null) {
            position = obj.transform.position;
            halfObjWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x/2;
            if (position.x + halfObjWidth <= posIniX) {
                Destroy(obj);
            }
        }

        if (bat != null) {
            position = bat.transform.position;
            halfBatWidth = bat.GetComponent<SpriteRenderer>().bounds.size.x/2;
            if (position.x + halfBatWidth <= posIniX) {
                Destroy(bat);
            }
        }

        if (skull != null) {
            position = skull.transform.position;
            halfSkullWidth = skull.GetComponent<SpriteRenderer>().bounds.size.x/2;
            if (position.x + halfSkullWidth <= posIniX) {
                Destroy(skull);
            }
        }

    }
    
}
