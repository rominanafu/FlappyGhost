using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

// Update current and maximum score
public class ScoreCounter : MonoBehaviour {

    int score;
    int maxScore;
    bool isBlue = true;
    float ghostPosX;

    // Set initial score values
    void Start() {
        score = 0;
        maxScore = 0;
    }

    // Change color of all blue/green elements
    void ChangeColors() {

        GameObject obj = GameObject.FindGameObjectWithTag("StripeUp");
        if (obj != null) {
            obj.GetComponent<StripeUpSettings>().ChangeStripe(isBlue);
        }
        obj = GameObject.FindGameObjectWithTag("StripeDown");
        if (obj != null) {
            obj.GetComponent<StripeDownSettings>().ChangeStripe(isBlue);
        }
        obj = GameObject.FindGameObjectWithTag("Background");
        if (obj != null) {
            obj.GetComponent<BackgroundSettings>().ChangeBackground(isBlue);
        }
        obj = GameObject.FindGameObjectWithTag("ScoreBox");
        if (obj != null) {
            obj.GetComponent<ScoreBoxSettings>().ChangeBox(isBlue);
        }
        obj = GameObject.FindGameObjectWithTag("CurrentScore");
        if (obj != null) {
            obj.GetComponent<CurrScore>().ChangeColor(isBlue);
        }
        obj = GameObject.FindGameObjectWithTag("MaxScore");
        if (obj != null) {
            obj.GetComponent<MaxScore>().ChangeColor(isBlue);
        }

    }

    // Set the ghost's x position and update scores
    // (since this method is called when a new ghost is created,
    // the scores are updated as corresponding)
    public void SetGhostPosX(float value) {

        ghostPosX = value;

        // Update scores
        GameObject txt = GameObject.FindGameObjectWithTag("CurrentScore");
        if (txt != null) {
            txt.GetComponent<CurrScore>().UpdateScore(score);
        }
        txt = GameObject.FindGameObjectWithTag("MaxScore");
        if (txt != null) {
            txt.GetComponent<MaxScore>().UpdateScore(maxScore);
        }

        // Blue color
        isBlue = true;
        ChangeColors();

    }

    // Check leading tomb's position for score update 
    public bool AddPoint(float tombPosX) {
        if (tombPosX <= ghostPosX) {
            score += 1;
            if (score % 10 == 0) { // Sound effect every 10 points
                GetComponent<AudioSource>().Play();
            }
            if (score % 20 == 0) { // Change color every 20 points
                isBlue = !isBlue;
                ChangeColors();
            }
            GameObject txt = GameObject.FindGameObjectWithTag("CurrentScore");
            if (txt != null) {
                txt.GetComponent<CurrScore>().UpdateScore(score);
            }
            maxScore = (score > maxScore ? score : maxScore);
            return true;
        }
        return false;
    }

    public void RestartScore() {
        score = 0;
    }

}
