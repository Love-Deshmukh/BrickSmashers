using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Launch()
    {
        rb.velocity = new Vector2(speed, speed);
    }

    void Update()
    {
        if (rb.velocity != Vector2.zero)
            rb.velocity = rb.velocity.normalized * speed;
    }
}