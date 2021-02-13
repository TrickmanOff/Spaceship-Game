using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossShipBehavior : MonoBehaviour
{
    public GameObject explosion;
    public int hp = 50;

    public Animator[] gunsAnimators;

    public void Update()
    {
        if (hp <= 0)
        {
            Animator _animator = GetComponent<Animator>();
            _animator.SetTrigger("Die");
        }
    }
    public void StopShooting()
    {
        foreach (Animator _anim in gunsAnimators)
            _anim.SetTrigger("Die");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Laser")
        {
            hp--;
            Instantiate(explosion, col.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
        }
    }
}
