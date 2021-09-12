using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.UI;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text scoreText;

    public InputField playerInputField;

    public void StartNewGame()
    {
        MainDataManager.Instance.PlayerName = playerInputField.text;
        MainDataManager.Instance.Save();
        SceneManager.LoadScene(1);
    }

    public void CloseApp()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = MainDataManager.Instance.ScoreText;
        playerInputField.text = MainDataManager.Instance.PlayerName;
    }

    
}
