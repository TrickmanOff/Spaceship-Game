using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenBullionBehavior : MonoBehaviour
{
    public float speed;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Destroy(this.gameObject);
            DataManager.instance.gold++;
        }
    }

    public void Update()
    {
        this.transform.Translate(new Vector2(0, speed * Time.deltaTime));
    }
}
