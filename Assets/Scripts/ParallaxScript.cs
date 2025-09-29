using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    public float ParallaxSpeed;
    private float GameTime = 0.0F;
    public float ParallaxOffset;
    public Vector2 ParallaxDirection;
    private Vector2 pixel_size = new Vector2(0,0);
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

        moving_direction.x = original_pos.x + ((GameTime * ParallaxSpeed + ParallaxOffset) % (pixel_size.y * image_scale.y)) * ParallaxDirection.x;
        moving_direction.y = original_pos.y + ((GameTime * ParallaxSpeed + ParallaxOffset) % (pixel_size.y * image_scale.y)) * ParallaxDirection.y;

        transform.position = moving_direction;
    }
}
