//using NUnit.Framework.Constraints;
using System;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Muzan : MonoBehaviour
{
    private double GameTime;

    private int ScoreIndex = 8;

    public GameObject Tanjiro;
    public GameObject Giyu;

    //public GameObject HighScorePrefab;

    //private GameObject HighScoreManager;

    //private int Player1Score = 0;
    //private int Player2Score = 0;

    private double ScoreIncrement_time_stamp = 0.0;

    private float[] PointTable = { 0, 100, 200, 1000 };

    private float[] Player1HighScores = { -1, -1, -1, -1, -1 };
    private float[] Player2HighScores = { -1, -1, -1, -1, -1 };
    private float[] Player1Stats = new float[9];
    private float[] Player2Stats = new float[9];

    private float[] CurrentRunPlayer1Stats = new float[9];
    private float[] CurrentRunPlayer2Stats = new float[9];

    private float[] Points = { 1, 100, 1000, 0, 200, 200, 0, 0, 0 };

    private bool InGame = false;

    /*
        Stats:
            Time
            Yellow Coins
            Blue Coins
            Dash Coins
            Dashes
            Kills by Sword
            Kills by Dash
            Wins
            Score

        Player Scoring:

        0: 1/10th of a second = 1 point
        1: Basic Coin = 100 points
        2: Killing a demon = 200 points
        3: Special Coin = 1,000 points
    */


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        GameTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (InGame)
        {
            TimerScore();
            PlayersAlive();
            DEBUG__PrintStats();
            UpdateScore();
        }

    }

    public void UpdateScore()
    {
        if (!Tanjiro.IsUnityNull())
        {
            CurrentRunPlayer1Stats[ScoreIndex] = 0;
        }
        if (!Giyu.IsUnityNull())
        {
            CurrentRunPlayer2Stats[ScoreIndex] = 0;
        }
        for (int i = 0; i < CurrentRunPlayer1Stats.Length; i++)
        {
            if (!Tanjiro.IsUnityNull())
            {
                CurrentRunPlayer1Stats[ScoreIndex] += Points[i] * CurrentRunPlayer1Stats[i];
            }
            if (!Giyu.IsUnityNull()) {
                CurrentRunPlayer2Stats[ScoreIndex] += Points[i] * CurrentRunPlayer2Stats[i];
            }
        }
    }



    public void IntoTheInfinityCastle()
    {
        InGame = true;
    }

    public void LeaveTheCastle()
    {
        InGame = false;
        NewRun(); // clears current run stats
    }
    private void TimerScore()
    {
        GameTime += Time.deltaTime;

        if (ScoreIncrement_time_stamp + 0.1f <= GameTime)
        {
            ScoreIncrement_time_stamp = GameTime;
            if (Tanjiro != null)
            {
                AddPlayerCurrentRunStat(0, 0);
            }
            if (Giyu != null)
            {
                AddPlayerCurrentRunStat(1, 0);
            }
        }

    }

    public void NewRun()
    {
        CurrentRunPlayer1Stats = new float[9];
        CurrentRunPlayer2Stats = new float[9];
    }

    private void PlayersAlive()
    {
        if (Tanjiro.IsUnityNull() && Giyu.IsUnityNull())
        {
            addNewHighScorePlayer(0, CurrentRunPlayer1Stats[ScoreIndex]);
            addNewHighScorePlayer(1, CurrentRunPlayer2Stats[ScoreIndex]);
            UpdateWinner();
            UpdateTotalStats();
            InGame = false;
            SceneManager.LoadScene("GameOverScene");
        }
    }
    private void UpdateWinner() {
        if (CurrentRunPlayer1Stats[ScoreIndex] > CurrentRunPlayer2Stats[ScoreIndex])
        {
            CurrentRunPlayer1Stats[7]++;
        }
        else
        {
            CurrentRunPlayer2Stats[7]++;
        }
    }

    public float getPlayerCurrentRunStat(int player, int index)
    {
        if (player == 0)
        {
            return CurrentRunPlayer1Stats[index];
        }
        return CurrentRunPlayer2Stats[index];
    }
    public void AddPlayerCurrentRunStat(int player, int index)
    {
        if (player == 0)
        {
            CurrentRunPlayer1Stats[index] ++;
        }
        CurrentRunPlayer2Stats[index] ++;
    }
    public float[] getPlayerTotalStat(int player, int index)
    {
        if (player == 0)
        {
            return CurrentRunPlayer1Stats;
        }
        return CurrentRunPlayer2Stats;
    }
    public void AddPlayerTotalStat(int player, int index)
    {
        if (player == 0)
        {
            Player1Stats[index] += CurrentRunPlayer1Stats[index];
        }
        Player2Stats[index] += CurrentRunPlayer2Stats[index];
    }

    public void addNewHighScorePlayer(int player, float score)
    {
        if (score > Player1HighScores[4])
        {
            if (player == 0)
            {
                Player1HighScores[4] = score;
                Player1HighScores = SortList(Player1HighScores);
            }
            else
            {
                Player2HighScores[4] = score;
                Player2HighScores = SortList(Player2HighScores);
            }
        }
    }

    public float[] getHighScores(int player)
    {
        if (player == 0)
        {
            return Player1HighScores;
        }
        return Player2HighScores;
    }

    public String getStringPlayerStats(int player)
    {
        String final_str = "";
        if (player == 0)
        {
            final_str += CurrentRunPlayer1Stats[0] / 10 + "\n";
            for (int i = 1; i < CurrentRunPlayer1Stats.Length; i++)
            {
                final_str += CurrentRunPlayer1Stats[i];
                if (i + 1 < CurrentRunPlayer1Stats.Length)
                {
                    final_str += "\n";
                }
            }
            return final_str;
        }
        else
        {
            final_str += CurrentRunPlayer2Stats[0] / 10 + "\n";
            for (int i = 1; i < CurrentRunPlayer2Stats.Length; i++)
            {
                final_str += CurrentRunPlayer2Stats[i];
                if (i + 1 < CurrentRunPlayer2Stats.Length)
                {
                    final_str += "\n";
                }
            }
            return final_str;
        }
    }
    public String getStringPlayerTotalStats(int player)
    {
        String final_str = "";
        if (player == 0)
        {
            for (int i = 0; i < Player1Stats.Length; i++)
            {
                final_str += Player1Stats[i];
                if (i + 1 < Player1Stats.Length)
                {
                    final_str += "\n";
                }
            }
            return final_str;
        }
        else
        {
            for (int i = 0; i < Player2Stats.Length; i++)
            {
                final_str += Player2Stats[i];
                if (i + 1 < Player2Stats.Length)
                {
                    final_str += "\n";
                }
            }
            return final_str;
        }
    }

    public void UpdateTotalStats()
    {
        for (int i = 0; i < Player1Stats.Length; i++)
        {
            Player1Stats[i] += CurrentRunPlayer1Stats[i];
            Player2Stats[i] += CurrentRunPlayer2Stats[i];
        }
    }


    private float[] SortList(float[] HighScores)
    {
        bool NotInOrder = true;
        while (NotInOrder)
        {
            NotInOrder = false;
            for (int i = 0; i < HighScores.Length - 1; i++)
            {
                if (HighScores[i] < HighScores[i + 1])
                {
                    float switcher = HighScores[i];
                    HighScores[i] = HighScores[i + 1];
                    HighScores[i + 1] = switcher;
                    NotInOrder = true;
                }
            }
        }
        return HighScores;
    }





    private void DEBUG__PrintStats()
    {
        String str = "";
        for (int i = 0; i < CurrentRunPlayer1Stats.Length; i++)
        {
            str += CurrentRunPlayer1Stats[i] + " ";
        }
        //Debug.Log(str);
    }

}

