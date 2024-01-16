using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Control maximum score text
public class MaxScore : MonoBehaviour {

    // Set initial location
    void Start() {
        GameObject box = GameObject.FindGameObjectWithTag("ScoreBox");
        Vector3 location = new Vector3(0, 0, -5);
        if (box != null) {
            location = box.transform.position;
        }
        location.y -= GetComponent<TextMeshProUGUI>().GetPreferredValues().y / 2;
        location.z -= 1;
        transform.position = location;

        tag = "MaxScore";

        ChangeColor(true);
    }

    public void UpdateScore(int score) {
        string txt = score.ToString();
        txt = "00000".Substring(0, 5-txt.Length) + txt;
        GetComponent<TextMeshProUGUI>().text = txt;
    }

    public void ChangeColor(bool isBlue) {
        if (isBlue) {
            GetComponent<TextMeshProUGUI>().color = new Color32(64, 135, 233, 161);
        } else {
            GetComponent<TextMeshProUGUI>().color = new Color32(100, 220, 107, 161);
        }
    }

}
