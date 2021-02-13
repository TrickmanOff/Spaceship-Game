using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldLogic : MonoBehaviour
{
    Animator _animator;
    private GameObject spaceship;
    private float endTimer = 0.8f;
    
    enum Status
    {
        On,
        Breaking
    }

    Status status = Status.On;

    private void Start()
    {
        spaceship = GameObject.FindGameObjectWithTag("Player");
        _animator = GetComponent<Animator>();

        spaceship.GetComponent<PlayersGunManager>().shieldOn = true;
    }

    private void Update()
    {
        this.transform.position = new Vector2(spaceship.transform.position.x, spaceship.transform.position.y + 0.3f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Asteroid" || col.tag == "EnemyLaser" || col.tag == "EnemyShip")
        {
            Destroy(col.gameObject);
            if (status == Status.On) StartCoroutine(breakShield());
        }
    }

    IEnumerator breakShield()
    {
        status = Status.Breaking;
        _animator.Play("ShieldDisappear");
        yield return new WaitForSeconds(endTimer);

        spaceship.GetComponent<PlayersGunManager>().shieldOn = false;
        Destroy(this.gameObject);
    }
}
