using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int MoveSpeed;
    private Rigidbody2D rb;
    public int CoinType; // 0: basic coin, 1: rare coin, 2: dash coin
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityY = MoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int new_points = 0;
            int new_dashes = 0;
            if (CoinType == 0)
            { // basic coin
                new_points += 100;
            }
            else if (CoinType == 1)
            { // rare coin
                new_points += 1000;
            }
            else if (CoinType == 2)
            { // dash coin
                new_dashes++;
            }

            if (collision.gameObject.GetComponent<PlayerScript>().PlayerIndex == 0)
            {
                GameObject.Find("GameManager").GetComponent<Muzan>().AddPointsPlayer1(new_points);
                GameObject.Find("GameManager").GetComponent<Muzan>().Tanjiro.GetComponent<PlayerScript>().AddDashesPlayer(new_dashes);
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<Muzan>().AddPointsPlayer2(new_points);
                GameObject.Find("GameManager").GetComponent<Muzan>().Giyu.GetComponent<PlayerScript>().AddDashesPlayer(new_dashes);
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
