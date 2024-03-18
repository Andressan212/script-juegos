using UnityEngine;

public class AgarrarObjeto : MonoBehaviour
{
    private bool objetoLevantado = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            LevantarObjeto();
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
