using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Control current score text
public class CurrScore : MonoBehaviour {

    // Set initial location
    void Start() {
        GameObject box = GameObject.FindGameObjectWithTag("ScoreBox");
        Vector3 location = new Vector3(0, 0, -5);
        if (box != null) {
            location = box.transform.position;
        }
        location.y += GetComponent<TextMeshProUGUI>().GetPreferredValues().y / 2;
        location.z -= 1;
        transform.position = location;

        tag = "CurrentScore";
        ChangeColor(true);
    }

    public void UpdateScore(int score) {
        string txt = score.ToString();
        txt = "000".Substring(0, 3-txt.Length) + txt;
        GetComponent<TextMeshProUGUI>().text = txt;
    }

    public void ChangeColor(bool isBlue) {
        if (isBlue) {
            GetComponent<TextMeshProUGUI>().color = new Color32(64, 135, 233, 255);
        } else {
            GetComponent<TextMeshProUGUI>().color = new Color32(100, 220, 107, 255);
        }
    }

}
