using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public class ScoreManager
{
    private class ScoreData
    {
        public ScoreData(List<int> scoreboard)
        {
            Scoreboard = scoreboard;
        }

        public List<int> Scoreboard;
    }

    public int Score { get; private set; } = 0;
    public List<int> Scoreboard { get; private set; }

    public void ResetScore()
    {
        Score = 0;
    }

    private readonly string DataPath;

    public ScoreManager()
    {
        DataPath = $"{Application.persistentDataPath}/scoreboard.json";
        LoadFromDisk();
    }

    public void AddScore(int value)
    {
        Score += value;
    }

    public void UpdateScoreboard()
    {
        if (Score == 0) return;

        Scoreboard.Add(Score);
        Scoreboard = Scoreboard.OrderByDescending(s => s).Take(5).ToList();
        SaveToDisk();
    }

    public void LoadFromDisk()
    {
        if (File.Exists(DataPath))
        {
            string json = File.ReadAllText(DataPath);
            Scoreboard = JsonUtility.FromJson<ScoreData>(json).Scoreboard;
        }
        else
        {
            Scoreboard = new();
        }
    }

    public void SaveToDisk()
    {
        if (Scoreboard.Count == 0) return;

        ScoreData scoreData = new ScoreData(Scoreboard);
        string json = JsonUtility.ToJson(scoreData);
        File.WriteAllText(DataPath, json);
    }
}
