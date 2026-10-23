using UnityEngine;

public class NaveMovimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(movimientoH * velocidad, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }
    }
}