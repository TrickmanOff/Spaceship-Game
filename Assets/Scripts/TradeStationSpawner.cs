using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using System.Threading;
using UnityEngine;

public class TradeStationSpawner : MonoBehaviour
{
    public int spawnDistance;
    public GameObject tradeStation;
    public PrintDistance printDistance;
    public CameraFit _camera;

    private int spawned = -1;

    private void Update()
    {
        if (tradeStation.transform.position.y < _camera.y1 - 2f)
        {
            tradeStation.GetComponent<TradeStation>().move = false;
            tradeStation.transform.position = new Vector2(1.3f, 11.6f);

            tradeStation.SetActive(false);

            StopGameManager.instance.startSpawn();
            StopGameManager.instance.unfreezeDistance();
        }

        if(DataManager.instance.distance % 2000 == spawnDistance && spawned != DataManager.instance.distance / 2000)
        {
            Debug.Log("Spawning trade station...");
            StopGameManager.instance.stopSpawn();
            StopGameManager.instance.freezeDistance();

            tradeStation.SetActive(true);

            tradeStation.GetComponent<TradeStation>().move = true;
            spawned = DataManager.instance.distance / 2000;
        }
    }
}
