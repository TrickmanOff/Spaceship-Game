using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySphereBehavior : MonoBehaviour
{
    public float speed = -5f;
    public GameObject explosion;

    private void Update()
    {
        this.transform.Translate(new Vector2(0, speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Laser")
        {
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
