using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    public float ParallaxSpeed;
    private float GameTime = 0.0F;
    public float ParallaxOffset;
    private Vector2 pixel_size = new Vector2(0,0);
    private Vector3 image_scale = new Vector3(0, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pixel_size = GetComponent<SpriteRenderer>().size;
        image_scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        GameTime += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, (GameTime*ParallaxSpeed+ParallaxOffset)  % (pixel_size.y*image_scale.y), 0);
    }
}
