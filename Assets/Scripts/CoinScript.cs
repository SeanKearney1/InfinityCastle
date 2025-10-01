using System;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int MoveSpeed;
    private Rigidbody2D rb;

    private GameObject Muzan;
    public int CoinType; // 0: basic coin, 1: rare coin, 2: dash coin
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityY = MoveSpeed;
        Muzan = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Muzan != null)
        {
            int new_dashes = 0;

            if (CoinType == 3)
            {
                new_dashes++;
            }

            if (collision.gameObject.GetComponent<PlayerScript>().PlayerIndex == 0)
            {
                Muzan.GetComponent<Muzan>().AddPlayerCurrentRunStat(0, CoinType);
                Muzan.GetComponent<Muzan>().Tanjiro.GetComponent<PlayerScript>().AddDashesPlayer(new_dashes);
            }
            else
            {
                Muzan.GetComponent<Muzan>().AddPlayerCurrentRunStat(1, CoinType);
                Muzan.GetComponent<Muzan>().Giyu.GetComponent<PlayerScript>().AddDashesPlayer(new_dashes);
            }
            Destroy(this.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ScreenSpace"))
        {
            Destroy(this.gameObject);
        }
    }
}
