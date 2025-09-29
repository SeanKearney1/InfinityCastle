using TMPro;
using UnityEngine;

public class DashesUiScript : MonoBehaviour
{
    public int PlayerIndex;

    // Update is called once per frame
    void Update()
    {
        if (PlayerIndex == 0 && GameObject.Find("GameManager").GetComponent<Muzan>().Tanjiro != null)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().text = "Dashes: "+GameObject.Find("Player1").GetComponent<PlayerScript>().getDashCount();
        }
        else if (GameObject.Find("GameManager").GetComponent<Muzan>().Giyu != null)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().text = "Dashes: "+GameObject.Find("Player2").GetComponent<PlayerScript>().getDashCount();
        }    
    }
}
