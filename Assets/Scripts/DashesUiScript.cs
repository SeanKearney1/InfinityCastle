using TMPro;
using UnityEngine;

public class DashesUiScript : MonoBehaviour
{
    public int PlayerIndex;

    private GameObject Muzan;

    public GameObject Player1;
    public GameObject Player2;
    // Update is called once per frame

    private void Start()
    {
        Muzan = GameObject.Find("GameManager");
    }

    void Update()
    {
        if (PlayerIndex == 0 && Muzan.GetComponent<Muzan>().Tanjiro != null)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().text = "Dashes: "+ Player1.GetComponent<PlayerScript>().getDashCount();
        }
        else if (Muzan.GetComponent<Muzan>().Giyu != null)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().text = "Dashes: "+ Player2.GetComponent<PlayerScript>().getDashCount();
        }    
    }
}
