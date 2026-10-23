using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float velocidad = 2f;
    public float distanciaMaxima = 2f;
    public bool moverEnVertical = true;

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        // SOLO se recoge si quien lo toca es exactamente la pelota ("Carga")
        if (collision.gameObject.name == "Carga")
        {
            ControlCarga scriptCarga = collision.gameObject.GetComponent<ControlCarga>();
            if (scriptCarga != null)
            {
                scriptCarga.SumarOrbe();
            }

            Destroy(gameObject);
        }
    }
}