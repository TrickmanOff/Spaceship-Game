using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class ActiveMenu : MonoBehaviour
{
    public float speed = -10f;

    private float fieldHeight;
    
    private void Start()
    {
        SpriteRenderer field = GetComponent<SpriteRenderer>();
        fieldHeight = field.bounds.size.y;
    }

    void Update()
    {
        transform.Translate(new Vector3(0f, speed*Time.deltaTime, 0f));
        if (transform.position.y <= (16f - fieldHeight / 2))
            transform.position = new Vector3(0f, 16f, 0f);
    }
}
