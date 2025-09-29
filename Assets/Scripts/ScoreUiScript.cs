using TMPro;
using UnityEngine;

public class ScoreUiScript : MonoBehaviour
{
    public int PlayerIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerIndex == 0)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().text = ""+GameObject.Find("GameManager").GetComponent<Muzan>().GetPlayer1Score();
        }
        else
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().text = ""+GameObject.Find("GameManager").GetComponent<Muzan>().GetPlayer2Score();
        }
    }
}
