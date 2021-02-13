using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public GameObject explosion;
    public float speed;
    public GameObject laser;

    public float shotCooldown;
    public float firstShotCooldown;

    public GameObject[] boxes;
    public int[] drop_prob = {10, 10, 3, 3, 3};
    
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = firstShotCooldown;
    }

    void shoot()
    {
        if (timer <= 0)
        {
            Instantiate(laser, new Vector2(transform.position.x, transform.position.y - 1f), transform.rotation);
            timer = shotCooldown;
        }
        timer -= Time.deltaTime;
    }

    void move (){
        transform.Translate(new Vector2(0, speed * Time.deltaTime));
    }

    void spawn_box()
    {
        int dice = Random.Range(0, 100);
        for(int box = 0, sum = 0; box < boxes.Length; box++)
        {
            sum += drop_prob[box];
            if(dice <= sum)
            {
                Instantiate(boxes[box], transform.position, transform.rotation);
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Laser")
        {
            spawn_box();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        move();
        shoot();
        
    }
}
