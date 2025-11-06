using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    [SerializeField] private HighScoreManager highScoreManager;
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        scoreText.text = "";

        for (int i = 0; i < highScoreManager.highScores.Count; i++)
        {
            scoreText.text += $"{i + 1}. {highScoreManager.highScores[i]}\n";
        }
    }
}

