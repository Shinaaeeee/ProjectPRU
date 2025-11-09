using System.Collections.Generic;
using System.IO;
using UnityEngine;



[System.Serializable]
public class ScoreData
{
    public string name;
    public int score;

    public ScoreData(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}



public class HighScoreManager : MonoBehaviour
{
    private string filePath;
    public List<ScoreData> highScores = new List<ScoreData>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        filePath = Application.persistentDataPath + "/highscores.txt";

        LoadHighScores();
    }

    public void AddNewScore(string playerName, int score)
    {
        highScores.Add(new ScoreData(playerName, score));

        // Sort theo điểm giảm dần
        highScores.Sort((a, b) => b.score.CompareTo(a.score));

        // Chỉ giữ Top 5
        if (highScores.Count > 5)
            highScores.RemoveAt(5);

        SaveHighScores();
    }

    private void SaveHighScores()
    {
        List<string> lines = new List<string>();
        foreach (var s in highScores)
        {
            lines.Add(s.name + "," + s.score);
        }
        File.WriteAllLines(filePath, lines);
    }

    public void SavePlayerName(string nameInput)
    {
        PlayerPrefs.SetString("PlayerName", nameInput);
        PlayerPrefs.Save();
    }


    private void LoadHighScores()
    {
        highScores.Clear();

        if (!File.Exists(filePath))
        {
            SaveHighScores();
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split(',');
            if (parts.Length == 2 && int.TryParse(parts[1], out int score))
            {
                highScores.Add(new ScoreData(parts[0], score));
            }
        }

        // Fill lên đủ 5 nếu thiếu
        while (highScores.Count < 5)
            highScores.Add(new ScoreData("---", 0));
    }
}