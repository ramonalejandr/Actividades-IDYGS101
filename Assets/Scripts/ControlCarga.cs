using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlCarga : MonoBehaviour
{
    public float velocidadHorizontalInicial = 0f;
    public float fuerzaImpulso = 6f;

    [Header("Objetivo")]
    public int orbesNecesarios = 6
    ;
    public GameObject zonaMeta;

    [Header("Límites de Posición Aleatoria de la Meta")]
    public float minX = -6f;
    public float maxX = 6f;
    public float minY = -1f;
    public float maxY = 3f;

    private int orbesActuales = 0;
    private Rigidbody2D rb;
    private bool juegoTerminado = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.linearVelocity = new Vector2(velocidadHorizontalInicial, 0f);

        // La meta empieza desactivada
        if (zonaMeta != null)
        {
            zonaMeta.SetActive(false);
        }
    }

    void Update()
    {
        if (juegoTerminado) return;

        // Impulso vertical con Espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * fuerzaImpulso, ForceMode2D.Impulse);
        }
    }

    // Método que llaman los orbes al recolectarse
    public void SumarOrbe()
    {
        orbesActuales++;
        Debug.Log("Orbes: " + orbesActuales + " / " + orbesNecesarios);

        if (orbesActuales >= orbesNecesarios)
        {
            ActivarMetaAleatoria();
        }
    }

    void ActivarMetaAleatoria()
    {
        if (zonaMeta != null)
        {
            // 1. Calculamos una posición aleatoria en X e Y
            float azarX = Random.Range(minX, maxX);
            float azarY = Random.Range(minY, maxY);

            // 2. Teletransportamos la meta a ese lugar
            zonaMeta.transform.position = new Vector3(azarX, azarY, 0f);

            // 3. La encendemos
            zonaMeta.SetActive(true);
            Debug.Log($"¡Los 6 orbes listos! Meta activada en: ({azarX:F1}, {azarY:F1})");
        }
    }

    // 1. Por si la meta es sólida (Collider normal)
    void OnCollisionEnter2D(Collision2D collision)
    {
        VerificarContacto(collision.gameObject);
    }

    // 2. Por si la meta o el objeto es un Trigger (Atravesable)
    void OnTriggerEnter2D(Collider2D collider)
    {
        VerificarContacto(collider.gameObject);
    }

    void VerificarContacto(GameObject objetoTocado)
    {
        if (juegoTerminado) return;

        // Comprobamos si el objeto tocado es la meta
        if (objetoTocado == zonaMeta || objetoTocado.name.Contains("ZonaMeta"))
        {
            juegoTerminado = true;
            Debug.Log("🏆 ¡GANASTE! Llegaste a la meta con la carga.");
            Invoke(nameof(ReiniciarNivel), 2f); // Reinicia después de 2 segundos para celebrar
        }
        else if (objetoTocado.name == "Suelo")
        {
            juegoTerminado = true;
            Debug.Log("💥 ¡Cargamento destruido! La pelota cayó al suelo.");
            Invoke(nameof(ReiniciarNivel), 1f);
        }
    }

    void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}