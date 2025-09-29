//using NUnit.Framework;
//using UnityEditor.Callbacks;
using UnityEngine;

public class PillarLogicScript : MonoBehaviour
{

    public int MoveSpeed;
    private bool direction;

    private float WarnTime;

    public int ExpireTime;

    private float time_stamp;

    private Rigidbody2D rb;

    void Start()
    {
        time_stamp = Time.time;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time_stamp + WarnTime < Time.time)
        {
            MovePillar();
        }
        if (time_stamp + WarnTime + ExpireTime < Time.time)
        {
            Destroy(this.gameObject);
        }
    }

    private void MovePillar()
    {
        int dir_multiplier = 1;
        if (direction == false) // TRUE: starts on the left and moves towards the right hand of the screen.
        {
            dir_multiplier = -1;
        }
        rb.linearVelocityX = MoveSpeed * dir_multiplier;

    }


    public void SetPillarDirection(bool IsGoingRight)
    {
        direction = IsGoingRight;
    }


    public void SetWarnTime(float warn_time)
    {
        WarnTime = warn_time;
    }

    

}
