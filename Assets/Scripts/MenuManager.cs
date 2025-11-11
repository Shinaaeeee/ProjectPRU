using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    [SerializeField] private string adventureScene = "Map1";
    [SerializeField] private string endlessScene = "Map3Endless";

    
    public void PlayAdventure()
    {
        SceneManager.LoadScene(adventureScene);
    }

    public void PlayEndless()
    {
        SceneManager.LoadScene(endlessScene);
    }

}
