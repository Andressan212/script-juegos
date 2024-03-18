using UnityEngine;

public class ObjetoHablador : MonoBehaviour
{
    private bool esDeDia = true;
    private bool objetoLevantado = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interactuar();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            LevantarObjeto();
        }
    }

    void Interactuar()
    {
        if (esDeDia)
        {
            Debug.Log("El objeto habla de día");
        }
        else
        {
            Debug.Log("El objeto habla de noche");
        }
    }

    void LevantarObjeto()
    {
        if (!objetoLevantado)
        {
            Debug.Log("Objeto levantado con la tecla 'G'");
            objetoLevantado = true;
        }
        else
        {
            Debug.Log("Objeto ya está levantado");
        }
    }
}
