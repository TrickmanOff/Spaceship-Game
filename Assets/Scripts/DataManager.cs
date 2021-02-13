using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public int best_distance;
    public int gold;
    public int distance;
    public bool gameEnded = false;

    public void update_score()
    {
        if(instance.distance > instance.best_distance) { 
            instance.best_distance = instance.distance;
            string path = Application.persistentDataPath + "/score1.gd";
            StreamWriter writer = new StreamWriter(path);
                writer.WriteLine(instance.best_distance);
            writer.Close();
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            instance.gold = 0;
            instance.distance = 0;

            string path = Application.persistentDataPath + "/score1.gd";
            if (!File.Exists(path))
                File.WriteAllText(path, "0");

            instance.best_distance = int.Parse(new StreamReader(path).ReadLine());
        }
        else
            Destroy(this);
    }
}
