using UnityEngine;

public class CicloDiaNoche : MonoBehaviour
{
    public float duracionDia = 150.0f;  // Duración del día en segundos (2.5 minutos)
    public float duracionNoche = 150.0f; // Duración de la noche en segundos (2.5 minutos)

    void Start()
    {
        // Iniciar el ciclo día-noche al inicio del juego
        StartCoroutine(CicloDiaNocheCoroutine());
    }

    void Update()
    {
        // Tu lógica de actualización aquí
    }

    IEnumerator CicloDiaNocheCoroutine()
    {
        while (true)
        {
            // Es de día
            Debug.Log("¡Es de día!");
            yield return new WaitForSeconds(duracionDia);

            // Es de noche
            Debug.Log("¡Es de noche!");
            yield return new WaitForSeconds(duracionNoche);
        }
    }
}
