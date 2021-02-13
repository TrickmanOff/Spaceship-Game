using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGameManager : MonoBehaviour
{
    public static StopGameManager instance;

    public GameObject _asteroidSpawner, _goldenShipSpawner, _enemySpawner;
    private ISpawner asteroidSpawner, goldenShipSpawner, enemySpawner;

    public PrintDistance printDistance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        asteroidSpawner = _asteroidSpawner.GetComponent<ISpawner>();
        goldenShipSpawner = _goldenShipSpawner.GetComponent<ISpawner>();
        enemySpawner = _enemySpawner.GetComponent<ISpawner>();
    }

    public void stopSpawn()
    {
        asteroidSpawner.StopSpawn();
        goldenShipSpawner.StopSpawn();
        enemySpawner.StopSpawn();
    }
    public void startSpawn()
    {
        asteroidSpawner.StartSpawn();
        goldenShipSpawner.StartSpawn();
        enemySpawner.StartSpawn();
    }
    public void freezeDistance()
    {
        printDistance.StopCount();
    }
    public void unfreezeDistance()
    {
        Debug.Log("Distance was unfreezed");
        printDistance.StartCount();
    }
}
