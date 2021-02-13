//using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BatteryShooting : MonoBehaviour
{
    public float shotCooldown = 0.2f;

    private Gun2Behavior[] guns;
    private List<int> permutation = new List<int>();

    void RandomShuffle()
    {
        int n = permutation.Count() - 1;
        while(n > 0)
        {
            int k = Random.Range(0, n + 1);
            int t = permutation[k];
            permutation[k] = permutation[n];
            permutation[n] = t;
            n--;
        }
    }

    void Start()
    {
        guns = this.GetComponentsInChildren<Gun2Behavior>();

        for (int i = 0; i < guns.Length; i++) permutation.Add(i);
    }

    public void Shoot()
    {
        StartCoroutine(IShoot());
    }

    IEnumerator IShoot()
    {
        RandomShuffle();
        foreach(int p in permutation) {
            guns[p].Shoot();
            yield return new WaitForSeconds(shotCooldown);
        }
    }
}
