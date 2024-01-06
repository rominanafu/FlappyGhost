using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

// Indicate when a certain amount of seconds has passed
// Based on Dr. Tim Chamillard's "C# Programming for Unity Game Development" Specialization
public class Timer : MonoBehaviour {

    float totalSeconds = 0;
    float elapsedSeconds = 0;
    bool running = false;
    bool started = false;
    
    public float Duration {
        set {
            totalSeconds = value;
        }
    }

    public bool Finished {
        get {
            return running == false && started;
        }
    }

    public void Run() {
        if (totalSeconds > 0) {
            started = true;
            running = true;
            elapsedSeconds = 0;
        }
    }

    void Update()
    {
        if (running) {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds >= totalSeconds) {
                running = false;
            }
        }
    }

}
