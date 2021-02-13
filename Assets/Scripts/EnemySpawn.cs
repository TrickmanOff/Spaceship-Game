using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour, ISpawner
{
    public GameObject enemy;
    public float spawn_cooldown;
    private float timer;
    private bool stopSpawn = false;

    public void StopSpawn()
    {
        stopSpawn = true;
    }

    public void StartSpawn()
    {
        stopSpawn = false;
        timer = spawn_cooldown;
    }

    private void Start()
    {
        timer = spawn_cooldown;
    }

    void Update()
    {
        if (stopSpawn) return;

        if(timer <= 0)
        {
            timer = spawn_cooldown;
            float x = Random.Range(-4f, 4f);
            Instantiate(enemy, new Vector2(x, 9.7f), transform.rotation);
        }
        timer -= Time.deltaTime;
    }
}
