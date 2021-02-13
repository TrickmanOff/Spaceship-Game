using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserActivator : MonoBehaviour
{
    public GameObject laser;
    public int ammo;
    public float speed;

    private void Update()
    {
        transform.Translate(new Vector2(0, speed*Time.deltaTime));
    }
}
