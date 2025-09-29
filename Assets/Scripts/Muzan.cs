//using NUnit.Framework.Constraints;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Muzan : MonoBehaviour
{
    private double GameTime;

    public GameObject Tanjiro;
    public GameObject Giyu;

    private GameObject HighScores;

    private int Player1Score = 0;
    private int Player2Score = 0;

    private double ScoreIncrement_time_stamp = 0.0;

    private int[] PointTable = { 0, 100, 200, 500, 1000 };


    /*
        Player Scoring:

        0: 1/10th of a second = 1 point
        1: Basic Coin = 100 points
        2: Killing a demon = 200 points
        3: Destroying a building = 500 points
        4: Special Coin = 1,000 points
    */


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameTime = 0;
        HighScores = GameObject.Find("HighScores");
    }

    // Update is called once per frame
    void Update()
    {
        GameTime += Time.deltaTime;

        if (ScoreIncrement_time_stamp + 0.1 <= GameTime)
        {
            ScoreIncrement_time_stamp = GameTime;
            if (Tanjiro != null)
            {
                Player1Score += 1;
            }
            if (Giyu != null)
            {
                Player2Score += 1;
            }
        }

        PlayersAlive();
    }

    private void PlayersAlive()
    {
        if (Tanjiro == null && Giyu == null)
        {
            HighScores.GetComponent<HighScoreScript>().setCurrentRunScore(Player1Score,Player2Score);
            HighScores.GetComponent<HighScoreScript>().addNewScorePlayer1(Player1Score);
            HighScores.GetComponent<HighScoreScript>().addNewScorePlayer2(Player2Score);
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public int GetPlayer1Score()
    {
        return Player1Score;
    }
    public int GetPlayer2Score()
    {
        return Player2Score;
    }

    public void AddPointsPlayer1(int points)
    {
        Player1Score += points;
    }
    public void AddPointsPlayer2(int points)
    {
        Player2Score += points;
    }

    public void KilledDemomPlayer1()
    {
        Player1Score += PointTable[2];
    }
    public void KilledDemomPlayer2()
    {
        Player2Score += PointTable[2];
    }
}
