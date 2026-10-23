using UnityEngine;

public class CambioColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        // Busca automáticamente el componente SpriteRenderer de este mismo GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Método público: esto permite que OTRO script pueda llamarlo y pasarle un color
    public void CambiarColor(Color nuevoColor)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = nuevoColor;
        }
    }
}