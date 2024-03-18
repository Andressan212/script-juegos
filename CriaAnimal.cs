using UnityEngine;

public class CriaAnimal : MonoBehaviour
{
    public AudioClip sonidoNacimiento; // Sonido al nacer
    public float distanciaLlamadaMadre = 5f; // Distancia para llamar a la madre
    public LayerMask capaMadre;

    private AudioSource audioSource;
    private bool madreLlamada = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        EmitirSonidoNacimiento();
    }

    void Update()
    {
        if (!madreLlamada)
        {
            LlamarAMadre();
        }
    }

    void EmitirSonidoNacimiento()
    {
        audioSource.PlayOneShot(sonidoNacimiento);
    }

    void LlamarAMadre()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distanciaLlamadaMadre, capaMadre);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Madre"))
            {
                madreLlamada = true;
                // Lógica adicional para comunicarse con la madre
                Debug.Log("¡Llamando a la madre!");
                IntentarAlimentarse(collider.transform);
                break;
            }
        }
    }

    void IntentarAlimentarse(Transform madre)
    {
        // Lógica para intentar alimentarse de la madre
        // Por ejemplo, puedes llamar a un método en el script de la madre para compartir la leche
        if (madre != null)
        {
            AnimalHembra madreScript = madre.GetComponent<AnimalHembra>();
            if (madreScript != null)
            {
                madreScript.CompartirLecheConCria();
            }
        }
    }
}
