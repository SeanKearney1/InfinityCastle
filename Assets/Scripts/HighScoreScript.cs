using UnityEngine;
//using UnityEngine.Experimental.AI;

public class HighScoreScript : MonoBehaviour
{
    private int[] Player1HighScores = { -1, -1, -1, -1, -1 };
    private int[] Player2HighScores = { -1, -1, -1, -1, -1 };

    private int CurrentRunScorePlayer1;
    private int CurrentRunScorePlayer2;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
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
        CurrentRunScorePlayer1 = score1;
        CurrentRunScorePlayer2 = score2;
    }
    public int[] getCurrentRunScores()
    {
        int[] scores = { CurrentRunScorePlayer1, CurrentRunScorePlayer2 };
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
}
