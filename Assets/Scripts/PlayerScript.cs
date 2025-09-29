//using NUnit.Framework.Constraints;
//using Unity.VisualScripting;
//using UnityEditor.UI;
using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.Timeline;

public class PlayerScript : MonoBehaviour
{

    public int PlayerIndex;
    private float horizontal_input;
    private float vertical_input;
    private int DashCount = 0;
    private int DashMultiplier = 1;
    public int DashMultiplierMax;
    public float DashDuration;
    private double CurrentlyDashing_time_stamp = -10000.0;
    private double DashCooldown = 2.0;
    private double DashCooldown_time_stamp = 0.0;
    private Rigidbody2D rb;
    private double GameTime = 0.0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GameTime += Time.deltaTime;
        Dash();
        Move();
    }


    private void Move()
    {
        horizontal_input = 0;
        vertical_input = 0;
        if (PlayerIndex == 0)
        {
            if (Input.GetKey(KeyCode.D)) { horizontal_input++; }
            if (Input.GetKey(KeyCode.A)) { horizontal_input--; }
            if (Input.GetKey(KeyCode.W)) { vertical_input++; }
            if (Input.GetKey(KeyCode.S)) { vertical_input--; }
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow)) { horizontal_input++; }
            if (Input.GetKey(KeyCode.LeftArrow)) { horizontal_input--; }
            if (Input.GetKey(KeyCode.UpArrow)) { vertical_input++; }
            if (Input.GetKey(KeyCode.DownArrow)) { vertical_input--; }
        }
        rb.linearVelocity = new Vector2(DashMultiplier * 10 * horizontal_input, DashMultiplier * 10 * vertical_input);
    }

    public void AddDashesPlayer(int dashes)
    {
        DashCount += dashes;

    }
    private void Dash()
    {
        DashMultiplier = 1;
        if (DashCount > 0 && DashCooldown_time_stamp + DashCooldown < GameTime) //has dashes to use and is not on cooldown.
        {
            if (PlayerIndex == 0 && Input.GetKeyDown(KeyCode.LeftShift)) // is correct player pushing proper key.
            {
                CurrentlyDashing_time_stamp = GameTime;
                DashCount--;
                DashCooldown_time_stamp = GameTime;
                DashMultiplier = DashMultiplierMax;
            }
            else if (PlayerIndex == 1 && Input.GetKeyDown(KeyCode.RightControl)) // is correct player pushing proper key.
            {
                CurrentlyDashing_time_stamp = GameTime;
                DashCount--;
                DashCooldown_time_stamp = GameTime;
                DashMultiplier = DashMultiplierMax;
            }
        }
        if (CurrentlyDashing_time_stamp + DashDuration >= GameTime)
        {
            DashMultiplier = DashMultiplierMax;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Demon"))
        {
            if (DashMultiplier == DashMultiplierMax)
            {
                Destroy(collision.gameObject);
                if (PlayerIndex == 0) {
                    GameObject.Find("GameManager").GetComponent<Muzan>().KilledDemomPlayer1();
                }
                else {
                    GameObject.Find("GameManager").GetComponent<Muzan>().KilledDemomPlayer2();
                }
                
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ScreenSpace"))
        {
            Destroy(this.gameObject);
        }

    }

    public int getDashCount()
    {
        return DashCount;
    }
}
