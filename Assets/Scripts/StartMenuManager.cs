using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StartMenuManager : MonoBehaviour
{
    public static StartMenuManager instance;
    public int bestScore = 0;
    public string bestScoreUsername;
    public string actualUsername; // by default on inputfield at session start

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScoreUser();
    }
    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string bestScoreUsername;
        public string actualUsername;
    }
    public void SaveScoreUser()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.bestScoreUsername = bestScoreUsername;
        data.actualUsername = actualUsername;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScoreUser() 
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            bestScoreUsername = data.actualUsername;
            actualUsername = data.actualUsername;
        }
    }

}
