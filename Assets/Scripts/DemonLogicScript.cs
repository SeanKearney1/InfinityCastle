using System;
using UnityEditor.Callbacks;
using UnityEditor.UI;
using UnityEngine;

public class DemonLogicScript : MonoBehaviour
{
    private GameObject Tanjiro;
    private GameObject Giyu;
    public float DemonSpeed;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DemonSpeed *= UnityEngine.Random.Range(0.8f, 1.2f);
        Tanjiro = GameObject.Find("Player1");
        Giyu = GameObject.Find("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("DEMON!!!!!!");
        double TanjiroDistance = 0;
        double GiyuDistance = 0;

        TanjiroDistance = Math.Sqrt(Math.Pow(Tanjiro.transform.position.x - this.gameObject.transform.position.x,2)+Math.Pow(Tanjiro.transform.position.y - this.gameObject.transform.position.y,2));
        GiyuDistance = Math.Sqrt(Math.Pow(Giyu.transform.position.x - this.gameObject.transform.position.x,2)+Math.Pow(Giyu.transform.position.y - this.gameObject.transform.position.y,2));

        if (TanjiroDistance <= GiyuDistance)
        {
            SetDirection(Tanjiro.transform.position);
        }
        else
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
