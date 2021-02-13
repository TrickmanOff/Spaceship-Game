using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour
{
    void Update()
    {
        Destroy(this.gameObject, 0.5f);
    }
}
