using UnityEngine;

public class HighscoreUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void ShowPanel()
    {
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }


    public void OpenPanel()
    {
        panel.SetActive(true);
    }
}
