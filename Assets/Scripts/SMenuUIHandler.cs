using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class SMenuUIHandler : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TMP_InputField usernameIField;
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        if(StartMenuManager.instance.bestScore != 0)
        {
            scoreText.text = "Best Score : " + StartMenuManager.instance.bestScoreUsername + " : " + StartMenuManager.instance.bestScore;
        }
        if(StartMenuManager.instance.actualUsername != null)
        {
            usernameIField.text = StartMenuManager.instance.actualUsername;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartClicked()
    {
        StartMenuManager.instance.actualUsername = usernameIField.text;
        if(StartMenuManager.instance.actualUsername =="")
        {
            StartMenuManager.instance.actualUsername = "DefaultName";
        }
        SceneManager.LoadScene(1);
    }

    public void Exit() 
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        StartMenuManager.instance.SaveScoreUser();
    }
}
