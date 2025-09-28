using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class PlayerScript : MonoBehaviour
{

    public int PlayerIndex;
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
        if (PlayerIndex == 0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }
        else if (PlayerIndex == 1 && Input.GetKeyDown(KeyCode.RightShift))
        {
            Dash();
        }
        /////////////////////////////////////////////////////
        /////////////////////////////////////////////////////
        /////////////////////////////////////////////////////
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
        rb.linearVelocity = new Vector2(10 * horizontal_input, 10 * vertical_input);
    }


    private void Dash()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Demon"))
        {
            SceneManager.LoadScene("GameScene");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ScreenSpace"))
        {
            SceneManager.LoadScene("GameScene");           
        }

    }
}
