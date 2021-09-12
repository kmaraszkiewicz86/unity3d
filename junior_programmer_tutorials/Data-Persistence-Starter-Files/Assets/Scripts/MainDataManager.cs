using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainDataManager : MonoBehaviour
{
    public static MainDataManager Instance { get; private set; }

    public string ScoreText => $"Best Score: {PlayerName} {Score}";

    public string PlayerName { get; set; } = "N/A";

    public int Score { get; set; }

    private string playerSaveFilePath => Path.Combine(Application.persistentDataPath, "playerInfo.json");

    public void Save()
    {
        var playerInfo = new PlayerInfoSaveData
        {
            PlayerName = PlayerName,
            Score = Score
        };

        string playerInfoJson = JsonUtility.ToJson(playerInfo);

        File.WriteAllText(playerSaveFilePath, playerInfoJson);
    }

    public void Load()
    {
        if (!File.Exists(playerSaveFilePath))
        {
            return;
        }

        var playerInfoJson = File.ReadAllText(playerSaveFilePath);

        var playerInfo = JsonUtility.FromJson<PlayerInfoSaveData>(playerInfoJson);

        PlayerName = playerInfo.PlayerName;
        Score = playerInfo.Score;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }
}
