using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreUpdate : MonoBehaviour
{
    private Text txt;

    string convertDistance(int dist)
    {
        string s = "";
        while (dist > 0)
        {
            string curTriple = (dist % 1000).ToString();
            if (curTriple == "0") curTriple = "000";

            s = curTriple + " " + s;
            dist /= 1000;
        }
        return s;
    }

    private void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "MAX DISTANCE: \n" + convertDistance(DataManager.instance.best_distance);
    }
}
