using System;
using Unity.VisualScripting;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private float MoveSpeed;
    private Rigidbody2D rb;
    public GameObject CoinSpawnerScript;

    private bool ThatHeavyIsDead = false;
    private GameObject Muzan;
    public int CoinType; // 0: basic coin, 1: rare coin, 2: dash coin
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Muzan = GameObject.Find("GameManager");

        if (!Muzan.IsUnityNull())
        {
            if (CoinType == 1) { MoveSpeed = Muzan.GetComponent<Muzan>().customGameSettings.getYellowCoinSpeed(); }
            else if (CoinType == 2) { MoveSpeed = Muzan.GetComponent<Muzan>().customGameSettings.getRareCoinSpeed(); }
            else if (CoinType == 3) { MoveSpeed = Muzan.GetComponent<Muzan>().customGameSettings.getDashCoinSpeed(); }
        }
        Debug.Log("BRAND NEW COIN!!!!!!!!!!!!!!!!!!!! SPEED == " + MoveSpeed);
        rb.linearVelocityY = MoveSpeed;
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
            CoinKilled();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ScreenSpace"))
        {
            CoinKilled();
        }
    }

    private void CoinKilled()
    {
        if (!ThatHeavyIsDead)
        {
            CoinSpawnerScript.GetComponent<CoinSpawnerScript>().KilledCoin(CoinType);
            Destroy(this.gameObject);
        }
        ThatHeavyIsDead = true;    
    }
}
