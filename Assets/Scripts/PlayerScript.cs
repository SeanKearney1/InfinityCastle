using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class PlayerScript : MonoBehaviour
{
    private float horizontal_input;
    private float vertical_input;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Attack();
    }


    private void Move()
    {
        horizontal_input = Input.GetAxisRaw("Horizontal");
        vertical_input = Input.GetAxisRaw("Vertical");
        rb.linearVelocity = new Vector2(10 * horizontal_input, 10 * vertical_input);
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerKill"))
        {
            SceneManager.LoadScene("GameScene");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        SceneManager.LoadScene("GameScene");
    }
}
