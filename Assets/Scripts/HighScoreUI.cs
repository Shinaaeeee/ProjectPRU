using System.Collections.Generic;
using UnityEngine;

public class HighscoreUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject highscoreUIElementPrefab;
    [SerializeField] private Transform elementWrapper;

    private List<GameObject> uiElements = new List<GameObject>();

    private void OnEnable()
    {
        HighscoreHandler.onHighscoreListChanged += UpdateUI;
    }

    private void OnDisable()
    {
        HighscoreHandler.onHighscoreListChanged -= UpdateUI;
    }
    public void OpenPanel() => panel.SetActive(true);
    public void ShowPanel() => panel.SetActive(true);
    public void ClosePanel() => panel.SetActive(false);

    private void UpdateUI(List<HighscoreElement> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (i >= uiElements.Count)
            {
                var inst = Instantiate(highscoreUIElementPrefab, elementWrapper);
                uiElements.Add(inst);
            }

            var displayGO = uiElements[i];
            if (displayGO == null) continue;

            var display = displayGO.GetComponent<HighScoreDisplayElement>();
            if (display == null)
            {
                Debug.LogError("HighscoreUI: prefab instance missing HighScoreDisplayElement component.");
                continue;
            }

            var el = list[i];
            display.SetTexts(el.playerName, el.points);
        }
    }
}
