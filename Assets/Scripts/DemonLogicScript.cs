using UnityEditor.Callbacks;
using UnityEditor.UI;
using UnityEngine;

public class DemonLogicScript : MonoBehaviour
{
    private GameObject Tanjiro;
    public float DemonSpeed;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DemonSpeed *= Random.Range(0.8f, 1.2f);
        Tanjiro = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("DEMON!!!!!!");
        Vector2 demon_direction = new Vector2(0,0);
        demon_direction.x = Tanjiro.transform.position.x - this.transform.position.x;
        demon_direction.y = Tanjiro.transform.position.y - this.transform.position.y;

        demon_direction.Normalize();
        demon_direction *= DemonSpeed;
        //Debug.Log(demon_direction+"\n");
        rb.linearVelocity = demon_direction;
    }
}
