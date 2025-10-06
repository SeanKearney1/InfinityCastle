using UnityEngine;


/*
    This script handles the parallax backgound for 
    the title scene, game scene, and game over scene.
 */



public class ParallaxScript : MonoBehaviour
{
    public float ParallaxSpeed;
    private float GameTime = 0.0F;
    public float ParallaxOffset;
    public int AdditionalPanels;
    public Vector2 ParallaxDirection;
    private Vector2 pixel_size = new Vector2(0, 0);
    private Vector2 image_scale = new Vector2(0, 0);
    private Vector2 original_pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pixel_size = GetComponent<SpriteRenderer>().size;
        image_scale = transform.localScale;
        original_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GameTime += Time.deltaTime;

        Vector2 moving_direction = new Vector2(0, 0);

        moving_direction.x = GetDirection(original_pos.x, pixel_size.x, image_scale.x, ParallaxDirection.x);
        moving_direction.y = GetDirection(original_pos.y, pixel_size.y, image_scale.y, ParallaxDirection.y);

        transform.position = moving_direction;
    }


    private float GetDirection(float og_pos, float pixel_dim, float image_dim, float direction)
    {
        return og_pos + ((GameTime * ParallaxSpeed + ParallaxOffset) % (pixel_dim * image_dim * AdditionalPanels)) * direction;
    }
}
