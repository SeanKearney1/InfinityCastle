using TMPro;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class CurrentRunScoreScript : MonoBehaviour
{
    public int PlayerIndex;
    private GameObject HighScoreManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HighScoreManager = GameObject.Find("HighScores");
        if (!HighScoreManager.IsUnityNull())
        {

            int[] scores = HighScoreManager.GetComponent<HighScoreScript>().getCurrentRunScores();
            if (PlayerIndex == 0)
            {
                GetComponent<TextMeshProUGUI>().text = "" + scores[0];

            }
            else
            {
                GetComponent<TextMeshProUGUI>().text = "" + scores[1];
            }
        }
        else
        {
            int[] scores = { -1, -1, -1, -1, -1 };
            GetComponent<TextMeshProUGUI>().text = "" + scores[0];
            GetComponent<TextMeshProUGUI>().text = "" + scores[1];
        }

    }

}
