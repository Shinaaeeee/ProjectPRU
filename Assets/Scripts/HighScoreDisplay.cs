using TMPro;
using UnityEngine;

public class HighScoreDisplay : MonoBehaviour
{
    [SerializeField] private HighScoreManager highScoreManager;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        scoreText.text = "";

        for (int i = 0; i < highScoreManager.highScores.Count; i++)
        {
            var data = highScoreManager.highScores[i];
            scoreText.text += $"{i + 1}. {data.name} - {data.score}\n";
        }
    }
}
