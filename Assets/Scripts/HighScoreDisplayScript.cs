using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.SocialPlatforms.Impl;

public class HighScoreDisplayScript : MonoBehaviour
{
    public int PlayerIndex;
    public GameObject HighScorePrefab;

    private GameObject HighScoreManager;



    public void UpdateHighScores()
    {
        int[] scores = { -1, -1, -1, -1, -1 };
        String scores_str = "";

        if (HighScoreManager.IsUnityNull())
        {
            HighScoreManager = GameObject.Find("HighScores");
        }
        if (HighScoreManager.IsUnityNull()) {
            this.gameObject.GetComponent<TextMeshProUGUI>().text = "------\n------\n------\n------\n------";
            return; 
        }

        if (PlayerIndex == 0)
        {
            scores = HighScoreManager.GetComponent<HighScoreScript>().getPlayer1HighScores();
        }
        else
        {
            scores = HighScoreManager.GetComponent<HighScoreScript>().getPlayer2HighScores();
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
