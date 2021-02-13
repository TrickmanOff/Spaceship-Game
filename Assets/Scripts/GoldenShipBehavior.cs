using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenShipBehavior : MonoBehaviour
{
    public GameObject explosion;
    public GameObject goldBullion;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Laser")
        {
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            Instantiate(goldBullion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
