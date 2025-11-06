using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManagerEL : MonoBehaviour
{
    private int currentEnergy;
    [SerializeField] private int energyMuctieu = 5;
    
    private bool bossCall = false;
    [SerializeField] GameObject SpawnEnemy;
    [SerializeField] private GameObject GameUI;
    [SerializeField] Image energyBar;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject WinMenu;
    [SerializeField] private CinemachineCamera cam;
    [SerializeField] private GameObject Red;

    void Start()
    {
        currentEnergy = 0;
        UpdateEnergyBar();

        if (SceneManager.GetActiveScene().name.Equals("Map1")) { MainMenu(); audioManager.StopAudioGame(); }
        else { audioManager.PlayDefaultAudioSource(); }

        cam.Lens.OrthographicSize = 5;
        Red.SetActive(false);
    }

    public void AddEnergy()
    {
        if (bossCall) { return; }
        currentEnergy += 1;
        UpdateEnergyBar();
        //if (currentEnergy == energyMuctieu)
        //{
            
        //}
    }
    
    private void UpdateEnergyBar()
    {
        if (energyBar != null)
        {
            float fillAmount = Mathf.Clamp01((float)currentEnergy / (float)energyMuctieu);
            energyBar.fillAmount = fillAmount;
        }

    }
    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 0f;

    }
    public void GameOverMenu()
    {
        gameOverMenu.SetActive(true);
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void PauseGameMenu()
    {
        pauseMenu.SetActive(true);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 1f;
        audioManager.PlayDefaultAudioSource();
    }
    public void ResumeGame()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Wingame()
    {
        WinMenu.SetActive(true);
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        Time.timeScale = 0f;
    }

}
