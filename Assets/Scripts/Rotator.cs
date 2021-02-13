using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public CircleCollider2D collider;

    private int angle;
    private float sc;
    
    void Start()
    {
        //setup random size of the asteroid
        angle = Random.Range(-5, 5);
        sc = Random.Range(0.2f, 0.5f);
        transform.localScale = new Vector3(sc, sc, sc);
        collider.radius = 2*sc;
    }

    void Update()
    {
        //rotate the asteroid
        transform.rotation *= Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
    }
}
