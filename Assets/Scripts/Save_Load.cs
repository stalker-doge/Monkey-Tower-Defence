using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Save_Load : MonoBehaviour
{
    private struct SaveData
    {
        public int currentLevel;
    }
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>30)
        {
            Save();
            timer = 0;
        }

    }

    void Save()
    {
        SaveData data;
        data.currentLevel = FindObjectOfType<LevelLoader>().GetCurrentLevel();
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            FindObjectOfType<LevelLoader>().LoadLevel(data.currentLevel);
        }
    }
    public void NewSave()
    {
        SaveData data;
        data.currentLevel = 1;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
