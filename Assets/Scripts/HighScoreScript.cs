using System;
using UnityEngine;
//using UnityEngine.Experimental.AI;

public class HighScoreScript : MonoBehaviour
{
    private int[] Player1HighScores = { -1, -1, -1, -1, -1 };
    private int[] Player2HighScores = { -1, -1, -1, -1, -1 };
    private int[] Player1Stats = new int[9];
    private int[] Player2Stats = new int[9];

    private int[] CurrentRunPlayer1Stats = new int[9];
    private int[] CurrentRunPlayer2Stats = new int[9];

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
    */

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        // dummy data test.
        //Player1Stats[0] = 100; Player1Stats[1] = 100; Player1Stats[2] = 100;
        //CurrentRunPlayer1Stats[0] = 10; CurrentRunPlayer1Stats[1] = 11; CurrentRunPlayer1Stats[2] = 89;
    }

    public int[] getPlayer1HighScores()
    {
        Player1HighScores = SortList(Player1HighScores);
        return Player1HighScores;
    }
    public int[] getPlayer2HighScores()
    {
        Player2HighScores = SortList(Player2HighScores);
        return Player2HighScores;
    }

    public void setCurrentRunScore(int score1, int score2)
    {
        CurrentRunPlayer1Stats[8] = score1;
        CurrentRunPlayer2Stats[8] = score2;
    }
    public int[] getCurrentRunScores()
    {
        int[] scores = { CurrentRunPlayer1Stats[8], CurrentRunPlayer2Stats[8] };
        return scores;
    }

    public void addNewScorePlayer1(int score)
    {
        if (score > Player1HighScores[4])
        {
            Player1HighScores[4] = score;
            Player1HighScores = SortList(Player1HighScores);
        }
    }
    public void addNewScorePlayer2(int score)
    {
        if (score > Player2HighScores[4])
        {
            Player2HighScores[4] = score;
            Player2HighScores = SortList(Player2HighScores);
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


    private int[] SortList(int[] HighScores)
    {
        bool NotInOrder = true;
        while (NotInOrder)
        {
            NotInOrder = false;
            for (int i = 0; i < HighScores.Length - 1; i++)
            {
                if (HighScores[i] < HighScores[i + 1])
                {
                    int switcher = HighScores[i];
                    HighScores[i] = HighScores[i + 1];
                    HighScores[i + 1] = switcher;
                    NotInOrder = true;
                }
            }
        }
        return HighScores;
    }


    public String getPlayer1Stats()
    {
        String output = "";
        for (int i = 0; i < CurrentRunPlayer1Stats.Length; i++)
        {
            output += CurrentRunPlayer1Stats[i];
            if (i + 1 < CurrentRunPlayer1Stats.Length)
            {
                output += "\n";
            }
        }
        return output;
    }
    public String getPlayer2Stats()
    {
        String output = "";
        for (int i = 0; i < CurrentRunPlayer2Stats.Length; i++)
        {
            output += CurrentRunPlayer2Stats[i];
            if (i + 1 < CurrentRunPlayer2Stats.Length)
            {
                output += "\n";
            }
        }
        return output;
    }




    public String getPlayer1TotalStats()
    {
        String output = "";
        for (int i = 0; i < Player1Stats.Length; i++)
        {
            output += Player1Stats[i];
            if (i + 1 < Player1Stats.Length)
            {
                output += "\n";
            }
        }
        return output;
    }
    public String getPlayer2TotalStats()
    {
        String output = "";
        for (int i = 0; i < Player2Stats.Length; i++)
        {
            output += Player2Stats[i];
            if (i + 1 < Player2Stats.Length)
            {
                output += "\n";
            }
        }
        return output;
    }
}
