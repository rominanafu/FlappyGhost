using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

// Script for spawning flying bats in background
public class FlyingBatSpawner : MonoBehaviour {

    [SerializeField]
    GameObject prefabBat;

    // Spawn control
    const float MinSpawnDelay = 0.5f;
    const float MaxSpawnDelay = 2f;
    Timer spawnTimer;

    // Bat sizes
    float halfHeight, halfWidth;

    // Begin timer and calculate bat sizes
    void Start() {
        // Timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
        spawnTimer.Run();

        // Bat sizes
        halfWidth = prefabBat.GetComponent<SpriteRenderer>().bounds.size.x/2;
        halfHeight = prefabBat.GetComponent<SpriteRenderer>().bounds.size.y/2;
    }

    // Spawn bat in random height
    void SpawnBat() {
        Vector3 location = new Vector3(Screen.width, Random.Range(0, Screen.height), 0);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        worldLocation.x += halfWidth;
        worldLocation.y += (worldLocation.y > 0 ? -halfHeight : halfHeight);
        worldLocation.z = 1;
        GameObject bat = Instantiate<GameObject>(prefabBat, worldLocation, Quaternion.identity);
    }

    // Call SpawnBat() and restart timer after spawn delay
    void Update() {
        if (spawnTimer.Finished) {
            SpawnBat();
            spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
            spawnTimer.Run();
        } 
    }

}
