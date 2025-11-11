using UnityEngine;
using UnityEngine.SceneManagement;
public class GameUI : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameManagerEL gameManagerEL;
    public void StartGame()
    {
        gameManager.StartGame();
    }
    public void StartGame1()
    {
        SceneManager.LoadScene("Map1");
    }

    public void PlayEndless()
    {
        Debug.Log("Đã load Map3Endless");
        SceneManager.LoadScene("Map3Endless"); // chuyen toi map3endless
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


