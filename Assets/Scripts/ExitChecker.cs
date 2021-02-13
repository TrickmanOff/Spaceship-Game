using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitChecker : MonoBehaviour
{
    public float timerAfterDeath = 3f;
    public static void exit()
    {
        DataManager.instance.update_score();
        DataManager.instance.distance = 0;
        DataManager.instance.gold = 0;
        DataManager.instance.gameEnded = false;
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (!GameObject.FindWithTag("Player"))
        {
            DataManager.instance.gameEnded = true;
            timerAfterDeath -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Escape) || timerAfterDeath <= 0)
            exit();
    }
}
