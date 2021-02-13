using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class PlayersGunManager : MonoBehaviour
{
    public GameObject defaultLaser;
    public int ammo = 20;
    public float shotCooldown = 0.25f;
    public GameObject explosion;
    public bool shieldOn = false;

    private float timer;
    private GameObject curLaser;

    private void Start()
    {
        timer = shotCooldown;
        curLaser = defaultLaser;
    }

    private void shoot()
    {
        if (timer < 0)
        {
            timer = shotCooldown;
            Instantiate(curLaser, new Vector2(transform.position.x, transform.position.y + 1f), transform.rotation);

            if (ammo > 0)
            {
                ammo--;
                if (ammo == 0) curLaser = defaultLaser;
            }
        }
        timer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "LaserActivator")
        {
            GameObject obj = col.gameObject;
            LaserActivator info = obj.GetComponent<LaserActivator>();
            ammo = info.ammo;
            curLaser = info.laser;
            Destroy(col);
        }   
        else if(col.tag == "EnemyLaser" || col.tag == "EnemyShip" || col.tag == "Asteroid" || col.tag == "Boss")
        {
            if (shieldOn) return;
            Debug.Log(col.gameObject.name);
            Handheld.Vibrate();
            Instantiate(explosion, transform.position, transform.rotation);
            
            Destroy(this.gameObject);

            if(col.tag != "Boss")
                Destroy(col.gameObject);
        }
    }

    private void Update()
    {
        shoot();
    }
}
