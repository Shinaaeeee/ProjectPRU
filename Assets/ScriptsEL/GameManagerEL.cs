using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    // Tham chiếu đến manager/obj hiển thị HighScore
    [SerializeField] private HighScoreManager highScoreManager;


    [SerializeField] private GameObject highScoreText;


    void Start()
    {
        currentEnergy = 0;
        UpdateEnergyBar();

        if (SceneManager.GetActiveScene().name.Equals("Map1")) { MainMenu(); audioManager.StopAudioGame(); }
        else { audioManager.PlayDefaultAudioSource(); }

        cam.Lens.OrthographicSize = 5;
        Red.SetActive(false);

        // đảm bảo trạng thái hiển thị highscore đúng khi bắt đầu
        if (highScoreManager != null)
        {
            // bật hiển thị khi bắt đầu game (nếu muốn)
            highScoreManager.gameObject.SetActive(true);
            highScoreManager.enabled = true;
        }
    }

    public void AddEnergy()
    {
        if (bossCall) { return; }
        currentEnergy += 1;
        UpdateEnergyBar();
    }

    private void UpdateEnergyBar()
    {
        if (energyBar != null)
        {
            float fillAmount = Mathf.Clamp01((float)currentEnergy / (float)energyMuctieu);
            energyBar.fillAmount = fillAmount;
        }
    }

    // Hàm helper để ẩn/hiện HighScore
    private void SetHighScoreVisible(bool visible)
    {
        if (highScoreManager == null) return;

        // nếu HighScoreManager là component trên cùng GameObject chứa UI highscore,
        // SetActive để ẩn toàn bộ UI; disabled component để ngưng logic cập nhật (nếu cần)
        highScoreManager.gameObject.SetActive(visible);

        // Nếu bạn muốn component script vẫn chạy nhưng chỉ ẩn UI, comment 2 dòng trên
        // và dùng dòng dưới để chỉ bật/tắt component:
        // highScoreManager.enabled = visible;
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 0f;

        // HIỆN LẠI TEXT HIGHSCORE
        if (highScoreText != null)
            highScoreText.SetActive(true);
    }

    public void GameOverMenu()
    {
        // Lưu điểm vào High Score
        string playerName = PlayerPrefs.GetString("PlayerName", "---");
        highScoreManager.AddNewScore(playerName, score);

        gameOverMenu.SetActive(true);
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 0f;
        // ẨN TEXT HIGHSCORE
        if (highScoreText != null)
            highScoreText.SetActive(false);

    }

    public void PauseGameMenu()
    {
        pauseMenu.SetActive(true);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 0f;

        // HIỆN LẠI TEXT HIGHSCORE
        if (highScoreText != null)
            highScoreText.SetActive(true);
    }

    public void StartGame()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 1f;
        audioManager.PlayDefaultAudioSource();

        // HIỆN LẠI TEXT HIGHSCORE
        if (highScoreText != null)
            highScoreText.SetActive(true);
    }

    public void ResumeGame()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 1f;

        SetHighScoreVisible(true);

        // HIỆN LẠI TEXT HIGHSCORE
        if (highScoreText != null)
            highScoreText.SetActive(true);
    }

    public void Wingame()
    {

        string playerName = PlayerPrefs.GetString("PlayerName", "---");
        highScoreManager.AddNewScore(playerName, score);

        WinMenu.SetActive(true);
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        Time.timeScale = 0f;

        // có thể ẩn hoặc hiện highscore tùy ý khi thắng
        SetHighScoreVisible(true);

        // HIỆN LẠI TEXT HIGHSCORE
        if (highScoreText != null)
            highScoreText.SetActive(true);
    }

    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }
    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MenuGame");
    }

}
