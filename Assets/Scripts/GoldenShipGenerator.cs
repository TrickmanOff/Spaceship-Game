using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class GoldenShipGenerator : MonoBehaviour, ISpawner
{
    public GameObject goldenShip;
    public CameraFit _camera;
    public float spawnCooldown;

    private float timer;
    private float x1 = -7, x2 = 7, y1, y2;
    private bool stopSpawn = false;

    public void StopSpawn()
    {
        stopSpawn = true;
    }

    public void StartSpawn()
    {
        stopSpawn = false;
        timer = spawnCooldown;
    }

    void SpawnGoldenShip()
    {
        Vector2 startPoint, endPoint;

        int flip = Random.Range(1, 3);
        startPoint.x = x1;
        endPoint.x = x2;

        if(flip % 2 == 0)
        {
            startPoint.x = x1;
            endPoint.x = x2;
        }
        else
        {
            startPoint.x = x2;
            endPoint.x = x1;
        }

        startPoint.y = Random.Range(y1, y2);
        endPoint.y = Random.Range(y1, y2);

        GameObject curShip = Instantiate(goldenShip, startPoint, Quaternion.identity);
        GoldenShipMove curShipMove = curShip.GetComponent<GoldenShipMove>();
        curShipMove.move = endPoint - startPoint;
    }

    void Start()
    {
        timer = spawnCooldown;
        y1 = 1f / 3 * (_camera.y2 - _camera.y1) + _camera.y1;
        y2 = _camera.y2;
        y1 += 1;
        y2 -= 1;
        Debug.Log(x1 + " " + x2 + " " + y1 + " " + y2);
    }

    private void Update()
    {
        if (stopSpawn) return;

        if(timer <= 0)
        {
            SpawnGoldenShip();
            timer = spawnCooldown;
        }
        timer -= Time.deltaTime;
    }

}
