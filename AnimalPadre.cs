using UnityEngine;

public class AnimalPadre : MonoBehaviour
{
    public float distanciaComida = 10f;
    public float velocidadBusqueda = 5f;
    public LayerMask capaComida;

    private Transform objetivoComida;

    void Update()
    {
        BuscarComida();
    }

    void BuscarComida()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distanciaComida, capaComida);

        if (colliders.Length > 0)
        {
            objetivoComida = colliders[0].transform;
            // Lógica adicional para moverse hacia la comida
            MoverHaciaComida();
        }
        else
        {
            objetivoComida = null;
        }
    }

    void MoverHaciaComida()
    {
        if (objetivoComida != null)
        {
            transform.LookAt(objetivoComida);
            transform.Translate(Vector3.forward * velocidadBusqueda * Time.deltaTime);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (objetivoComida != null && other.transform == objetivoComida)
        {
            // Lógica para compartir comida con las crías
            if (other.CompareTag("Comida"))
            {
                CompartirComidaConCriaturas();
            }
        }
    }

    void CompartirComidaConCriaturas()
    {
        // Lógica para compartir comida con las crías
        Debug.Log("Compartiendo comida con las crías.");
    }
}
