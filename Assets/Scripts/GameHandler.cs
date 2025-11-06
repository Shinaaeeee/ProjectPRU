using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] HighscoreHandler highscoreHandler;
    [SerializeField] string playerName;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
    }

    public void StopGame()
    {
        highscoreHandler.AddHighscoreIfPossible(
            new HighscoreElement(playerName, gameManager.GetScore())
        );

        Time.timeScale = 0f;
    }
}
