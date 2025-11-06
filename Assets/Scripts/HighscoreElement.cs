using System;

[Serializable]
public class HighscoreElement
{
    public string playerName;
    public int points;

    public HighscoreElement(string name, int score)
    {
        playerName = name;
        points = score;
    }
}
