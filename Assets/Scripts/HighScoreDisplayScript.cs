using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.SocialPlatforms.Impl;

/*
  This script handles the text for the high score display,
  and replaces null values (-1) with -------- when there are less than
  5 highscores.
 */



public class HighScoreDisplayScript : MonoBehaviour
{
    public int PlayerIndex;

    private GameObject Muzan;



    public void UpdateHighScores()
    {
        float[] scores = { -1, -1, -1, -1, -1 };
        String scores_str = "";

        if (Muzan.IsUnityNull())
        {
            Muzan = GameObject.Find("GameManager");
        }
        if (Muzan.IsUnityNull()) {
            this.gameObject.GetComponent<TextMeshProUGUI>().text = "------\n------\n------\n------\n------";
            return; 
        }


        scores = Muzan.GetComponent<Muzan>().getHighScores(PlayerIndex);


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
