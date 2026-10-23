using UnityEngine;

public class Controlar_Pelotita : MonoBehaviour
{
    public float velocidadHorizontal = 3f;
    public float fuerzaImpulso = 4f;
    public float velocidadMaxima = 12f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.linearVelocity = new Vector2(
            velocidadHorizontal,
            0f
        );
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(
                Vector2.up * fuerzaImpulso,
                ForceMode2D.Impulse
            );
        }

        if (rb.linearVelocity.magnitude > velocidadMaxima)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * velocidadMaxima;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Canasta"))
        {
            Debug.Log("Anotación");
        }
        
    }
}