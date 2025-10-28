using UnityEngine;
using UnityEngine.SceneManagement;
public class GameUI : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public void StartGame()
    {
        gameManager.StartGame();
    }
    public void StartGame1()
    {
        SceneManager.LoadScene("Map1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ContinueGame()
    {
        gameManager.ResumeGame();
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
