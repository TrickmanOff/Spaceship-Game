using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintDistance : MonoBehaviour
{
    Text _text;
    Animator _animator;

    public float timeInHundred;
    private float timer = 0;
    private bool stopCount = false;

    public void StopCount()
    {
        stopCount = true;
        Debug.Log("Distance counting stopped");
    }

    public void StartCount()
    {
        stopCount = false;
    }

    void Start()
    {
        _text = GetComponent<Text>();
        _animator = GetComponent<Animator>();
        
        DataManager.instance.distance = 0;
        timer = timeInHundred;
    }

    string convertDistance(int dist)
    {
        string s = "";
        while(dist > 0)
        {
            string curTriple = (dist % 1000).ToString();
            if (curTriple == "0") curTriple = "000";

            s = curTriple + " " + s;
            dist /= 1000;
        }
        return s;
    }

    void Update()
    {
        if (timer <= 0 && !DataManager.instance.gameEnded)
        {
            DataManager.instance.distance += 100;
            _text.text = convertDistance(DataManager.instance.distance);

            _animator.Play("DistanceAnimation");

            timer = timeInHundred;
        }

        if (stopCount) return;
        timer -= Time.deltaTime;
    }
}
