using System.Collections;
using System.Collections.Generic;
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
    }
}
