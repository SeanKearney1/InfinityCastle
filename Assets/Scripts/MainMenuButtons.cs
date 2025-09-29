using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject HighscorePanel;
    public GameObject Player1HighScoreText;
    public GameObject Player2HighScoreText;
    void Start()
    {
        HighscorePanel.SetActive(false);
    }
    public void Play()
    {

        SceneManager.LoadScene("GameScene");
    }

    public void Exit()
    {
        Application.Quit();
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
