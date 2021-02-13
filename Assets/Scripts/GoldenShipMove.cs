using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenShipMove : MonoBehaviour
{
    public Vector2 move;
    public float timeOnScreen;

    private void Update()
    {
        transform.Translate(move /timeOnScreen *Time.deltaTime);
    }
}
