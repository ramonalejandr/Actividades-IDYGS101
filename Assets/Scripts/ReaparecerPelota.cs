using UnityEngine;

public class ReaparecerPelota : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Canasta"))
        {
            transform.position = new Vector3(-2f, -1f, 0f);
            rb.linearVelocity = Vector2.zero;
        }
    }
}