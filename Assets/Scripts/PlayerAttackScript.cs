using UnityEditor.Toolbars;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    private float AttackDuration = 1.5f;
    private float AttackCooldown = 3.0f;
    private bool IsAttacking = false;
    private float Attacking_time_stamp = 0.0f;
    private float Attack_cooldown_time_stamp = 0.0f;

    private int PlayerIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerIndex = this.GetComponentInParent<PlayerScript>().PlayerIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (Attack_cooldown_time_stamp + AttackCooldown < Time.time)
        {
            if (PlayerIndex == 0 && Input.GetKeyDown(KeyCode.Q))
            {
                Attacking_time_stamp = Time.time;
                Attack_cooldown_time_stamp = Time.time;
            }
            else if (PlayerIndex == 1 && Input.GetKeyDown(KeyCode.Space))
            {
                Attacking_time_stamp = Time.time;
                Attack_cooldown_time_stamp = Time.time;
            }
        }
        Debug.Log("Attack_cooldown_time_stamp = " + Attack_cooldown_time_stamp);
        Debug.Log("++++: " + Attacking_time_stamp + " + " + AttackDuration + " >= " + Time.time);
        if (Attacking_time_stamp + AttackDuration >= Time.time)
        {
            Debug.Log(Time.time + " IS Attacking!!!");
            IsAttacking = true;
        }
        else
        {
            Debug.Log(Time.time + " IS NOT Attacking!!!");
            IsAttacking = false;
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsAttacking) {
            if (collision.gameObject.CompareTag("Demon"))
            {
                Debug.Log("KILLED A DEMON");
                Destroy(collision.gameObject);
            }
        }
    }
}
