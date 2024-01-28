using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Rendering;

// Spawn tomb pairs depending on previous
// tomb pair position
public class TombPosSpawner : MonoBehaviour {

    [SerializeField]
    GameObject[] prefabTombs;
    [SerializeField]
    GameObject prefabKillerSkull;
    [SerializeField]
    GameObject prefabStripe;

    // Spawn control
    const float SpawnSpaceDelay = 5f;
    float deltaX = 5;
    float firstPosX;
    GameObject lastTomb = null;

    // Initial impulse force for tombs spawning
    float tombImpulse;

    // Pairs of tombs
    Tuple<int,int>[] tombsPairs = {Tuple.Create(1, 6), Tuple.Create(2, 5), Tuple.Create(3, 5),
                                Tuple.Create(5, 3), Tuple.Create(5, 2), Tuple.Create(6, 1), Tuple.Create(2, 6),
                                Tuple.Create(6, 2), Tuple.Create(6, 6)};
    int tombsPairsAmount;

    // Sprites sizes
    float[] halfHeightTombs = new float[8];
    float[] halfWidthTombs = new float[8];
    float stripeSize;

    // Tombs to then check scores
    Queue<GameObject> queueTombs = new Queue<GameObject>();

    bool running = false;
    bool gameOver = false;
    int lastKillerSkullCont = 0;

    // Calculate width and height sizes of sprites
    void Start() {        
        // Calculate sizes
        for(int i=0; i<7; i++) {
            halfWidthTombs[i] = prefabTombs[i].GetComponent<SpriteRenderer>().bounds.size.x / 2;
            halfHeightTombs[i] = prefabTombs[i].GetComponent<SpriteRenderer>().bounds.size.y / 2;
        }
        tombsPairsAmount = tombsPairs.Length;
        stripeSize = prefabStripe.GetComponent<SpriteRenderer>().bounds.size.y * 0.7f / 6;
    }

    public void SetGameOver(bool value=true) {
        gameOver = value;
        if (value == false) {
            running = false;
        }
    }

    // Spawn a skull between two prefabTombs[6]
    void SpawnSkull(float x) {
        Vector3 locationSkull = new Vector3(x, 0, 0);
        prefabKillerSkull.GetComponent<SkullMovement>().SetImpulseForce = tombImpulse;
        GameObject skull = Instantiate<GameObject>(prefabKillerSkull, locationSkull, Quaternion.identity);
    }

    // Spawn a random pair of tombs
    void SpawnTombs() {

        int ind = UnityEngine.Random.Range(0, tombsPairsAmount);
        if (lastKillerSkullCont >= 7) {
            ind = tombsPairsAmount-1;
        } else if (ind == tombsPairsAmount-1 && lastKillerSkullCont < 1) {
            // Avoid consecutive killer skulls
            ind = UnityEngine.Random.Range(0, tombsPairsAmount-1);
        }
        
        // Lower tomb spawning
        Vector3 locationItem1 = new Vector3(Screen.width, 0, 0);
        locationItem1 = Camera.main.ScreenToWorldPoint(locationItem1);
        locationItem1.x += halfWidthTombs[tombsPairs[ind].Item1];
        locationItem1.y += halfHeightTombs[tombsPairs[ind].Item1] + stripeSize;
        locationItem1.z = 0;

        prefabTombs[tombsPairs[ind].Item1].GetComponent<TombMovement>().SetImpulseForce = tombImpulse;
        Vector3 newScale = prefabTombs[tombsPairs[ind].Item1].transform.localScale;
        prefabTombs[tombsPairs[ind].Item1].transform.localScale = (newScale.x > 0 ? newScale : newScale*-1);

        GameObject tombDown = Instantiate<GameObject>(prefabTombs[tombsPairs[ind].Item1],
                                                        locationItem1, Quaternion.identity);

        // Upper tomb spawning
        Vector3 locationItem2 = new Vector3(Screen.width, Screen.height, 0);
        locationItem2 = Camera.main.ScreenToWorldPoint(locationItem2);
        locationItem2.x += halfWidthTombs[tombsPairs[ind].Item2];
        locationItem2.y -= halfHeightTombs[tombsPairs[ind].Item2] + stripeSize;
        locationItem2.z = 0;

        newScale = prefabTombs[tombsPairs[ind].Item2].transform.localScale;
        prefabTombs[tombsPairs[ind].Item2].transform.localScale = (newScale.x < 0 ? newScale : newScale*-1);
        prefabTombs[tombsPairs[ind].Item2].GetComponent<TombMovement>().SetImpulseForce = tombImpulse;

        GameObject tombUp = Instantiate<GameObject>(prefabTombs[tombsPairs[ind].Item2],
                                                    locationItem2, Quaternion.identity);

        // Saving the last tomb initial position and object to track it in Update()
        firstPosX = tombDown.transform.position.x;
        lastTomb = tombDown;

        // Saving one of the tombs in the queue
        queueTombs.Enqueue(tombDown);

        // Add the Killer Skull when the two pairs of tombs is (6, 6)
        if (ind == tombsPairsAmount-1) {
            SpawnSkull(locationItem1.x);
            lastKillerSkullCont = 0;
        } else {
            lastKillerSkullCont += 1;
        }

    }

    // Call SpawnTombs() when the delay has been reached
    void Update() {
        // Begin spawning when there is a click or space button is pressed
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) {
            if (!gameOver && !running) {
                running = true;
                lastTomb = null;
                deltaX = SpawnSpaceDelay;
                tombImpulse = -2f;
                queueTombs.Clear();
            }
        }
        if (!running) {
            return;
        }

        // Spawn new pair if the last one has reached SpawnSpaceDelay
        if (deltaX >= SpawnSpaceDelay) {
            SpawnTombs();
            tombImpulse -= 0.05f;
            deltaX = 0;
        }

        if (lastTomb != null) {

            deltaX = firstPosX - lastTomb.transform.position.x;

            bool delete = Camera.main.GetComponent<ScoreCounter>().AddPoint(queueTombs.Peek().transform.position.x);
            if (delete) {
                queueTombs.Dequeue();
            }

        }
    }

}
