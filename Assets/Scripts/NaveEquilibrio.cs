using UnityEngine;

public class NaveEquilibrio : MonoBehaviour
{
    public float fuerza = 8f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direccion = new Vector2(
            horizontal,
            vertical
        );

        rb.AddForce(direccion * fuerza);
    }
}