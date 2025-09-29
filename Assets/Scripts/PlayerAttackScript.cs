//using UnityEditor.Toolbars;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    private double AttackDuration = 1.5;
    private double AttackCooldown = 3.0;
    private bool IsAttacking = false;
    private double Attacking_time_stamp = 0.0;
    private double Attack_cooldown_time_stamp = 0.0;

    private double GameTime = 0;

    private int PlayerIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerIndex = this.GetComponentInParent<PlayerScript>().PlayerIndex;
    }

    // Update is called once per frame
    void Update()
    {

        GameTime += Time.deltaTime;

        if (Attack_cooldown_time_stamp + AttackCooldown < GameTime)
        {
            if (PlayerIndex == 0 && Input.GetKeyDown(KeyCode.Q))
            {
                Attacking_time_stamp = GameTime;
                Attack_cooldown_time_stamp = GameTime;
            }
            else if (PlayerIndex == 1 && Input.GetKeyDown(KeyCode.Space))
            {
                Attacking_time_stamp = GameTime;
                Attack_cooldown_time_stamp = GameTime;
            }
        }
        //Debug.Log("Attack_cooldown_time_stamp = " + Attack_cooldown_time_stamp);
        //Debug.Log("++++: " + Attacking_time_stamp + " + " + AttackDuration + " >= " + GameTime);
        if (Attacking_time_stamp + AttackDuration >= GameTime)
        {
            //Debug.Log(GameTime + " IS Attacking!!!");
            IsAttacking = true;
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
        else
        {
            //Debug.Log(GameTime + " IS NOT Attacking!!!");
            IsAttacking = false;
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsAttacking) {
            if (collision.gameObject.CompareTag("Demon"))
            {
                //Debug.Log("KILLED A DEMON");
                Destroy(collision.gameObject);
                if (PlayerIndex == 0) {
                    GameObject.Find("GameManager").GetComponent<Muzan>().KilledDemomPlayer1();
                }
                else {
                    GameObject.Find("GameManager").GetComponent<Muzan>().KilledDemomPlayer2();
                }
            }
        }
    }
}
