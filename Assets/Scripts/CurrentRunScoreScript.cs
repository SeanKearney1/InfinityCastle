using TMPro;
using UnityEngine;

public class CurrentRunScoreScript : MonoBehaviour
{
    public int PlayerIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int[] scores = GameObject.Find("HighScores").GetComponent<HighScoreScript>().getCurrentRunScores();
        if (PlayerIndex == 0)
        {
            GetComponent<TextMeshProUGUI>().text = "" + scores[0];
            
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = "" + scores[1];
        }

    }

}
