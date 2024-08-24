using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SMenuUIHandler : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        if(StartMenuManager.instance.bestScore != 0)
        {
            scoreText.text = "Best Score : " + StartMenuManager.instance.bestScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit() 
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
