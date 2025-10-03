using System;
using Unity.VisualScripting;

//using UnityEditor.Callbacks;
//using UnityEditor.UI;
using UnityEngine;

public class DemonLogicScript : MonoBehaviour
{
    private GameObject Tanjiro;
    private GameObject Giyu;
    private float DemonSpeed;
    private Rigidbody2D rb;
    private GameObject Muzan;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DemonSpeed *= UnityEngine.Random.Range(0.8f, 1.2f);

        Muzan = GameObject.Find("GameManager");

        if (!Muzan.IsUnityNull())
        {
            Tanjiro = Muzan.GetComponent<Muzan>().Tanjiro;
            Giyu = Muzan.GetComponent<Muzan>().Giyu;
            DemonSpeed = Muzan.GetComponent<Muzan>().customGameSettings.getDemonSpeed();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("DEMON!!!!!!");
        double TanjiroDistance = 0;
        double GiyuDistance = 0;

        if (Tanjiro != null) {
            TanjiroDistance = Math.Sqrt(Math.Pow(Tanjiro.transform.position.x - this.gameObject.transform.position.x, 2) + Math.Pow(Tanjiro.transform.position.y - this.gameObject.transform.position.y, 2));
        }
        else {
            TanjiroDistance = 99999999;
        }
        if (Giyu != null) {
            GiyuDistance = Math.Sqrt(Math.Pow(Giyu.transform.position.x - this.gameObject.transform.position.x, 2) + Math.Pow(Giyu.transform.position.y - this.gameObject.transform.position.y, 2));
        }
        else {
            GiyuDistance = 99999999;
        }
        if (TanjiroDistance <= GiyuDistance && Tanjiro != null)
        {
            SetDirection(Tanjiro.transform.position);
        }
        else if (Giyu != null)
        {
            SetDirection(Giyu.transform.position);
        }

    }


    private void SetDirection(Vector3 player_pos)
    {
        Vector2 demon_direction = new Vector2(0, 0);
        demon_direction.x = player_pos.x - this.transform.position.x;
        demon_direction.y = player_pos.y - this.transform.position.y;

        demon_direction.Normalize();
        demon_direction *= DemonSpeed;
        rb.linearVelocity = demon_direction;      
    }
}
