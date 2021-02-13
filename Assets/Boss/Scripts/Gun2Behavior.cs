using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2Behavior : MonoBehaviour
{
    public GameObject laser;

    public void Shoot()
    {
        Instantiate(laser, new Vector2(this.transform.position.x, this.transform.position.y - 1f), Quaternion.identity);
    }

}
