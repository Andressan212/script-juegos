using UnityEngine;

public class AnimalHembra : MonoBehaviour
{
    public Material colorBueno; // Material para crías con colores vivos
    public Material colorMalo; // Material para crías con colores apagados
    public GameObject prefabCria; // Prefab de la cría
    public Transform puntoNacimiento; // Punto de aparición de las crías

    private bool estaPreñada = false;
    private int diasGestacion = 5;
    private int diasPasados = 0;
    private int diasParaAlimentarCrias = 8;
    private int diasParaCrecer = 3;

    void Update()
    {
        if (estaPreñada)
        {
            diasPasados++;

            if (diasPasados >= diasGestacion)
            {
                // Dar a luz
                DarALuz();
            }
        }
    }

    void DarALuz()
    {
        // Reiniciar el contador de días
        diasPasados = 0;

        // Crear una cría
        GameObject nuevaCria = Instantiate(prefabCria, puntoNacimiento.position, Quaternion.identity);

        // Configurar el color de la cría según el color del animal hembra
        Renderer rendererCria = nuevaCria.GetComponent<Renderer>();
        if (EsColorBueno())
        {
            rendererCria.material = colorBueno;
            // Lógica adicional para cuidar y amar a la cría con color bueno
        }
        else
        {
            rendererCria.material = colorMalo;
            // Lógica adicional para matar a la cría con color malo
        }

        // Iniciar la cuenta regresiva para alimentar a la cría hasta la madurez
        StartCoroutine(AlimentarCria(nuevaCria));

        estaPreñada = false; // La hembra ya no está preñada
    }

    bool EsColorBueno()
    {
        // Lógica para determinar si el color del animal hembra es bueno o malo
        // Por ejemplo, si el color del animal es gris, marrón o verde oscuro
        return true; // Cambiar según tu lógica específica
    }

    public void QuedarPreñada()
    {
        estaPreñada = true;
    }

    IEnumerator AlimentarCria(GameObject cria)
    {
        int diasAlimentacion = diasParaAlimentarCrias;

        while (diasAlimentacion > 0)
        {
            Debug.Log("Alimentando a la cría. Días restantes: " + diasAlimentacion);
            yield return new WaitForSeconds(1.0f); // Un día en el juego
            diasAlimentacion--;
        }

        // La cría ha alcanzado la madurez, permitir que juegue y explore
        cria.GetComponent<CriaAnimal>().PermitirExplorar();
    }
}
