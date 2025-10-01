using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MainGUIButtons : MonoBehaviour
{
    public GameObject MainMenuMainPanel;
    public GameObject InGameMainPanel;
    public GameObject GameOverMainPanel;
    public GameObject HighscorePanel;
    public GameObject StatsPanel;
    public GameObject PauseDarkness;
    public GameObject Player1HighScoreText;
    public GameObject Player2HighScoreText;

    public GameObject Player1Stats;
    public GameObject Player2Stats;

    public GameObject Player1TotalStats;
    public GameObject Player2TotalStats;

    private GameObject Muzan;

    private bool gamePaused = false;
    public int GameScene;
    void Start()
    {
        Muzan = GameObject.Find("GameManager");
        MainMenuMainPanel.SetActive(false);
        InGameMainPanel.SetActive(false);
        GameOverMainPanel.SetActive(false);
        HighscorePanel.SetActive(false);
        StatsPanel.SetActive(false);
        PauseDarkness.SetActive(false);
        if (GameScene == 0)
        {
            MainMenuMainPanel.SetActive(true);
        }
        else if (GameScene == 2)
        {
            GameOverMainPanel.SetActive(true);
        }
    }
    void Update()
    {
        showPauseMenu();
    }
    public void Play()
    {

        SceneManager.LoadScene("GameScene");
    }

    public void Resume()
    {
        MainMenuMainPanel.SetActive(false);
        InGameMainPanel.SetActive(false);
        GameOverMainPanel.SetActive(false);
        HighscorePanel.SetActive(false);
        PauseDarkness.SetActive(false);
        StatsPanel.SetActive(false);
        Time.timeScale = 1.0f;
        gamePaused = false;
    }
    private void showPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameScene == 1)
        {
            if (!gamePaused)
            {
                MainMenuMainPanel.SetActive(false);
                InGameMainPanel.SetActive(true);
                GameOverMainPanel.SetActive(false);
                PauseDarkness.SetActive(true);
                StatsPanel.SetActive(false);
                Time.timeScale = 0.0f;
                gamePaused = true;
            }
            else
            {
                MainMenuMainPanel.SetActive(false);
                InGameMainPanel.SetActive(false);
                GameOverMainPanel.SetActive(false);
                HighscorePanel.SetActive(false);
                PauseDarkness.SetActive(false);
                StatsPanel.SetActive(false);
                Time.timeScale = 1.0f;
                gamePaused = false;
            }
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("TitleScene");
        Time.timeScale = 1.0f;
    }

    public void HighScores()
    {
        MainMenuMainPanel.SetActive(false);
        InGameMainPanel.SetActive(false);
        GameOverMainPanel.SetActive(false);
        HighscorePanel.SetActive(true);
        if (GameScene != 1)
        {
            PauseDarkness.SetActive(false);
        }
        StatsPanel.SetActive(false);
        Player1HighScoreText.GetComponent<HighScoreDisplayScript>().UpdateHighScores();
        Player2HighScoreText.GetComponent<HighScoreDisplayScript>().UpdateHighScores();
    }
    public void BackToMain()
    {
        if (GameScene == 0)
        {
            MainMenuMainPanel.SetActive(true);
        }
        else if (GameScene == 1)
        {
            InGameMainPanel.SetActive(true);
        }
        else if (GameScene == 2)
        {
            GameOverMainPanel.SetActive(true);
        }
        HighscorePanel.SetActive(false);
        if (GameScene != 1)
        {
            PauseDarkness.SetActive(false);
        }
        StatsPanel.SetActive(false);
    }

    public void Stats()
    {
        MainMenuMainPanel.SetActive(false);
        InGameMainPanel.SetActive(false);
        GameOverMainPanel.SetActive(false);
        HighscorePanel.SetActive(false);
        if (GameScene != 1)
        {
            PauseDarkness.SetActive(false);
        }
        StatsPanel.SetActive(true);

        FillStats();
    }


    private void FillStats()
    {
        if (Muzan.IsUnityNull())
        {
            Muzan = GameObject.Find("GameManager");
        }
        if (Muzan.IsUnityNull()) { return; }

        Player1Stats.GetComponent<TextMeshProUGUI>().text = Muzan.GetComponent<Muzan>().getStringPlayerStats(0);
        Player2Stats.GetComponent<TextMeshProUGUI>().text = Muzan.GetComponent<Muzan>().getStringPlayerStats(1);
        Player1TotalStats.GetComponent<TextMeshProUGUI>().text = Muzan.GetComponent<Muzan>().getStringPlayerTotalStats(0);
        Player2TotalStats.GetComponent<TextMeshProUGUI>().text = Muzan.GetComponent<Muzan>().getStringPlayerTotalStats(1);
    }

}
