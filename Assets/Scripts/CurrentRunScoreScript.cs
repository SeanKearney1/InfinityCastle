using TMPro;
using Unity.VisualScripting;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class CurrentRunScoreScript : MonoBehaviour
{
    public int PlayerIndex;
    private GameObject Muzan;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Muzan = GameObject.Find("GameManager");
        if (!Muzan.IsUnityNull())
        {
            GetComponent<TextMeshProUGUI>().text = "" + Muzan.GetComponent<Muzan>().getPlayerCurrentRunStat(PlayerIndex, 8);
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = "-1";
            GetComponent<TextMeshProUGUI>().text = "-1";
        }

    }

}
