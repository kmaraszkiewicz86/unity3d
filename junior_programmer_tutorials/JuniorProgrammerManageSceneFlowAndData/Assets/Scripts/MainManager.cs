using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public Color TeamColor;

    private string SavedDataFilePath =>
        Path.Combine(Application.persistentDataPath, "savedData.json");

    public void SaveData()
    {
        var colorData = new SaveData
        {
            TeamColor = TeamColor
        };

        var json = JsonUtility.ToJson(colorData);

        File.WriteAllText(SavedDataFilePath, json);
    }

    public void LoadData()
    {
        if (!File.Exists(SavedDataFilePath))
        {
            return;
        }

        var json = File.ReadAllText(SavedDataFilePath);

        var savedData = JsonUtility.FromJson<SaveData>(json);

        TeamColor = savedData.TeamColor;
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        LoadData();
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
