using UnityEngine;

public class ControlColision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Pared"))
        {
            Destroy(gameObject); 
        }
    }
}