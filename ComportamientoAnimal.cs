using UnityEngine;

public class ComportamientoAnimal : MonoBehaviour
{
    public Transform jugador; // El transform del jugador
    public float distanciaDeteccion = 5f; // Distancia para detectar al jugador
    public float distanciaHuida = 3f; // Distancia para huir del jugador
    public AudioClip sonidoHuida; // Sonido al huir

    private AudioSource audioSource;
    private bool jugadorDetectado = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Comprobar la distancia al jugador
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);

        // Si el jugador está dentro de la distancia de detección
        if (distanciaAlJugador < distanciaDeteccion)
        {
            if (!jugadorDetectado)
            {
                // El jugador ha sido detectado
                Debug.Log("¡Jugador detectado! ¡Acercándose y hablando!");
                jugadorDetectado = true;

                // Lógica adicional aquí, como reproducir sonido de hablar
            }

            // Acercarse al jugador
            transform.LookAt(jugador);
            transform.Translate(Vector3.forward * Time.deltaTime);

            // Lógica adicional aquí, como hablar con el jugador
        }
        else
        {
            // Si el jugador no está dentro de la distancia de detección
            jugadorDetectado = false;

            // Lógica adicional aquí, como dejar de hablar
        }

        // Si el jugador ataca y está dentro de la distancia de huida
        if (Input.GetButtonDown("Fire1") && distanciaAlJugador < distanciaHuida)
        {
            // Correr y esconderse
            Debug.Log("¡Jugador atacando! ¡Corriendo y escondiéndose!");
            audioSource.PlayOneShot(sonidoHuida); // Reproducir sonido de huida

            // Lógica adicional aquí, como correr y esconderse
        }
    }
}
