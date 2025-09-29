//using UnityEditor.UI;
using UnityEngine;

public class WarningKillMe : MonoBehaviour
{

    private float timeToKill;
    private float time_stamp;
    // Update is called once per frame
    void Update()
    {
        if (time_stamp + timeToKill < Time.time)
        {
            Destroy(this.gameObject);
        }
    }

    public void KillTime(float live_time)
    {
        timeToKill = live_time;
        time_stamp = Time.time;
    }
}
