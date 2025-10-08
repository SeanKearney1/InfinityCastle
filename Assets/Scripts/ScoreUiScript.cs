using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


/*
 
    Another script for passing information to
    UI elements, this one handles the current run scores for 
    each UI's repective player.
 
 */
public class ScoreUiScript : MonoBehaviour
{
    public int PlayerIndex;

    private GameObject Muzan;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Muzan = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (!Muzan.IsUnityNull())
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().text = "" + Muzan.GetComponent<Muzan>().getPlayerCurrentRunStat(PlayerIndex, 8);
        }
    }
}
