using UnityEngine;

public class ObstaculoMovil : MonoBehaviour
{
    public float velocidad = 3f;
    public float distanciaMaxima = 3f;
    public bool moverEnVertical = false;

    private Vector3 posicionInicial;
    private int direccion = 1;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        Vector3 eje = moverEnVertical ? Vector3.up : Vector3.right;
        transform.Translate(eje * direccion * velocidad * Time.deltaTime);

        float desplazamientoActual = moverEnVertical 
            ? transform.position.y - posicionInicial.y 
            : transform.position.x - posicionInicial.x;

        if (desplazamientoActual >= distanciaMaxima)
        {
            direccion = -1;
        }
        else if (desplazamientoActual <= -distanciaMaxima)
        {
            direccion = 1;
        }
    }
}