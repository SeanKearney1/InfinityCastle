using UnityEngine;

public class BuildingLogicScript : MonoBehaviour
{
    public int MoveSpeed;
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
            MoveBuilding();
        }
        if (time_stamp + WarnTime + ExpireTime < Time.time)
        {
            Destroy(this.gameObject);
        }
    }
    
    private void MoveBuilding()
    {
        rb.linearVelocityY = MoveSpeed;
    }

    public void SetWarnTime(float warn_time)
    {
        WarnTime = warn_time;
    }
}
