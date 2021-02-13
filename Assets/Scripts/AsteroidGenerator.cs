using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.EventSystems;

public class AsteroidGenerator : MonoBehaviour, ISpawner
{
    public GameObject asteroid;
    float timer;
    public float time_respawn = 0.25f;
    public int score;
    public int old_score;
    public int waveCount;
    private bool stopSpawn = false;

    public void StopSpawn()
    {
        stopSpawn = true;
    }

    public void StartSpawn()
    {
        stopSpawn = false;
        timer = time_respawn;
    }

    public void reloadSpawn()
    {
        timer = time_respawn;
    }

    void Start()
    {
        score = 0;
        timer = time_respawn;
        StreamReader scoredata = new StreamReader(Application.persistentDataPath + "/score1.gd");
        old_score = int.Parse(scoredata.ReadLine());
        scoredata.Close();
    }
    
    void spawnAsteroids()
    {
        // <x-pos, radius>
        List<Tuple<float, float>> poss = new List<Tuple<float, float>>();

        for (int i = 0; i < waveCount; )
        {
            float x = UnityEngine.Random.Range(-5f, 5f);
            float aster_radius = asteroid.GetComponent<CircleCollider2D>().radius;

            bool intersect = false;
            foreach(Tuple<float, float> ast in poss) {
                if (Math.Abs(ast.Item1 - x) < ast.Item2 + aster_radius)
                    intersect = true;
            }

            if (intersect) continue;

            i++;
            poss.Add(new Tuple<float, float> (x, aster_radius));
            Instantiate(asteroid, new Vector3(x, 9f + aster_radius, 0f), transform.rotation);
        }
    }

    void Update()
    {
        if (stopSpawn) return;

        if(timer < 0)
        {
            timer = time_respawn;
            spawnAsteroids();
        }
        timer -= Time.deltaTime;
    }
}
