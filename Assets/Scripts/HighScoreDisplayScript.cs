using System;
using TMPro;
using UnityEngine;
//using UnityEngine.SocialPlatforms.Impl;

public class HighScoreDisplayScript : MonoBehaviour
{
    public int PlayerIndex;

    public void UpdateHighScores()
    {
        int[] scores = { -1, -1, -1, -1, -1 };
        String scores_str = "";
        if (PlayerIndex == 0)
        {
            scores = GameObject.Find("HighScores").GetComponent<HighScoreScript>().getPlayer1HighScores();
        }
        else
        {
            scores = GameObject.Find("HighScores").GetComponent<HighScoreScript>().getPlayer2HighScores();
        }

        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] < 0)
            {
                scores_str += "------";
            }
            else
            {
                scores_str += scores[i];
            }
            if (i + 1 != scores.Length)
            {
                scores_str += "\n";
            }
        }


        this.gameObject.GetComponent<TextMeshProUGUI>().text = scores_str;
    }

}
