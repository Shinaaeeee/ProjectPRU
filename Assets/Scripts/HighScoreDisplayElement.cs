using TMPro;
using UnityEngine;

public class HighScoreDisplayElement : MonoBehaviour


{

    [SerializeField] private TextMeshProUGUI playerNameTxt;
    [SerializeField] private TextMeshProUGUI pointsTxt;

    public void SetTexts(string name, int score)
    {
        if (playerNameTxt != null)
            playerNameTxt.text = name;

        if (pointsTxt != null)
            pointsTxt.text = score.ToString();
    }
}
