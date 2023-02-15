using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Random=UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string TeamName;
    public string Name;
    public string Score;
    private void Awake()
    {
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    [System.Serializable]
    public class SaveData 
    {
        public string SaveScore;
        public string SaveName;
    }

     public void Save()
        {
                SaveData data = new SaveData();
                data.SaveScore = Score;
                data.SaveName = TeamName;
                string Json= JsonUtility.ToJson(data);
                File.WriteAllText(Application.persistentDataPath+"/savefile.json", Json);   
        }
        public void Load()
        {
            string loadPath = Application.persistentDataPath+"/savefile.json";
            if(File.Exists(loadPath))
            {
                string json = File.ReadAllText(loadPath);
                SaveData data = JsonUtility.FromJson<SaveData>(json);
                Score = data.SaveScore;
                TeamName = data.SaveName;
            }
        }
}
