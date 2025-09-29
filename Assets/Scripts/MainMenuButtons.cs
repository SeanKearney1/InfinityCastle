using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject HighscorePanel;
    public GameObject PauseDarkness;
    public GameObject Player1HighScoreText;
    public GameObject Player2HighScoreText;

    private bool gamePaused = false;
    public bool IsGameScene;
    void Start()
    {
        HighscorePanel.SetActive(false);
        if (IsGameScene)
        {
            MainPanel.SetActive(false);
            PauseDarkness.SetActive(false);
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
        MainPanel.SetActive(false);
        HighscorePanel.SetActive(false);
        PauseDarkness.SetActive(false);
        Time.timeScale = 1.0f;
        gamePaused = false;
    }
    private void showPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && IsGameScene) {
            if (!gamePaused)
            {
                MainPanel.SetActive(true);
                PauseDarkness.SetActive(true);
                Time.timeScale = 0.0f;
                gamePaused = true;
            }
            else
            {
                MainPanel.SetActive(false);
                HighscorePanel.SetActive(false);
                PauseDarkness.SetActive(false);
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
    }

    public void HighScores()
    {
        MainPanel.SetActive(false);
        HighscorePanel.SetActive(true);
        Player1HighScoreText.GetComponent<HighScoreDisplayScript>().UpdateHighScores();
        Player2HighScoreText.GetComponent<HighScoreDisplayScript>().UpdateHighScores();
    }
    public void HighScoresBack()
    {
        MainPanel.SetActive(true);
        HighscorePanel.SetActive(false);       
    }
}
