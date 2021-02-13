using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject boss;
    public int distance;

    private int spawned = 0;

    void Update()
    {
        if (DataManager.instance.distance % distance == 0 && DataManager.instance.distance / distance != spawned)
        {
            Instantiate(boss, new Vector2(0f, 7.81f), Quaternion.identity);
            spawned = DataManager.instance.distance / distance;
        }    
    }
}
