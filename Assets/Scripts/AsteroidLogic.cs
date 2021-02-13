using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLogic : MonoBehaviour
{
    public GameObject explosion;
    public float asteroidSpeed = -0.1f;
    
    void Update()
    {
        transform.Translate(new Vector3(0f, asteroidSpeed * Time.deltaTime, 0f));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "SystemControl")
            return;
        if (col.tag == "Laser")
        {
            Destroy(col.gameObject); //destroy the bullet

            //DataManager.instance.current_score++;
            //want to see if transform.rotation is neccessary
            Instantiate(explosion, transform.position, transform.rotation);

            Destroy(this.gameObject);
        }
    }
}
