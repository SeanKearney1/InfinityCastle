//using NUnit.Framework.Constraints;
//using Unity.VisualScripting;
//using UnityEditor.UI;
//using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
//using static Unity.VisualScripting.Dependencies.Sqlite.SQLite3;
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
    private bool CanAttackDash;

    private GameObject Muzan;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Muzan = GameObject.Find("GameManager");
        if (!Muzan.IsUnityNull())
        {
            CanAttackDash = Muzan.GetComponent<Muzan>().customGameSettings.getCanAttackDash();
        }
    }

    void Update()
    {
        GameTime += Time.deltaTime;
        if (CanAttackDash) { Dash(); }
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

        if (DashMultiplier == DashMultiplierMax) 
        {
            gameObject.GetComponentInChildren<Animator>().SetBool("IsDashing", true);
            DashingAngle(horizontal_input,vertical_input);
        }
        else
        {
            gameObject.GetComponentInChildren<Animator>().SetBool("IsDashing", false);
            gameObject.GetComponentInChildren<SpriteRenderer>().transform.rotation = Quaternion.Euler(0, 0, 0);
        }
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
                if (!Muzan.IsUnityNull())
                {
                    Muzan.GetComponent<Muzan>().AddPlayerCurrentRunStat(0, 4);
                }
            }
            else if (PlayerIndex == 1 && Input.GetKeyDown(KeyCode.RightControl)) // is correct player pushing proper key.
            {
                CurrentlyDashing_time_stamp = GameTime;
                DashCount--;
                DashCooldown_time_stamp = GameTime;
                DashMultiplier = DashMultiplierMax;
                if (!Muzan.IsUnityNull())
                {
                    Muzan.GetComponent<Muzan>().AddPlayerCurrentRunStat(0, 4);
                }

            }
        }
        if (CurrentlyDashing_time_stamp + DashDuration >= GameTime)
        {
            DashMultiplier = DashMultiplierMax;
        }
    }

    public bool IsPlayerDashing()
    {
        if (DashMultiplier != 1)
        {
            return true;
        }
        return false;
    }

    private void DashingAngle(float horizontal_input, float vertical_input)
    {
        Quaternion angles = Quaternion.Euler(0, 0, 0);
        if ((horizontal_input == 0 && vertical_input == 0) || (horizontal_input == 0 && vertical_input == 1)) // up or nothing
        {
            angles = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontal_input == -1 && vertical_input == 1) // up right
        {
            angles = Quaternion.Euler(0, 0, 45);
        }
        else if (horizontal_input == -1 && vertical_input == 0) // right
        {
            angles = Quaternion.Euler(0, 0, 90);
        }
        else if (horizontal_input == -1 && vertical_input == -1) // down right
        {
            angles = Quaternion.Euler(0, 0, 135);
        }
        else if (horizontal_input == 0 && vertical_input == -1) // down
        {
            angles = Quaternion.Euler(0, 0, 180);
        }
        else if (horizontal_input == 1 && vertical_input == -1) // down left
        {
            angles = Quaternion.Euler(0, 0, 225);
        }
        else if (horizontal_input == 1 && vertical_input == 0) // left
        {
            angles = Quaternion.Euler(0, 0, 270);
        }
        else if (horizontal_input == 1 && vertical_input == 1) // up left
        {
            angles = Quaternion.Euler(0, 0, 315);
        }
        gameObject.GetComponentInChildren<SpriteRenderer>().transform.rotation = angles;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Demon") && !GetComponentInChildren<PlayerAttackScript>().getIsAttacking() && !IsPlayerDashing())
        {
            Destroy(this.gameObject);
            Debug.Log("Killed By Demon");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ScreenSpace"))
        {
            Destroy(this.gameObject);
            Debug.Log("Killed By Out of Bounds");
        }

    }

    public int getDashCount()
    {
        return DashCount;
    }


    public void AnimateAttacker(bool attacking)
    {
        gameObject.GetComponentInChildren<Animator>().SetBool("IsAttacking",attacking);
    }
}
