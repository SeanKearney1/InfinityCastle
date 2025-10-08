using System;
using TMPro;
using UnityEngine;


/*
    This script is just another little script
    written so ui elements can grab data.

    This one grabes data for how many dashes
    the player has, and checks which player their UI
    covers.
*/


public class DashesUiScript : MonoBehaviour
{
    public int PlayerIndex;

    private String Dashes = "DASHES: ";

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
            this.gameObject.GetComponent<TextMeshProUGUI>().text = Dashes+ Player1.GetComponent<PlayerScript>().getDashCount();
        }
        else if (PlayerIndex == 1 && Muzan.GetComponent<Muzan>().Giyu != null)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().text = Dashes+ Player2.GetComponent<PlayerScript>().getDashCount();
        }    
    }
}
