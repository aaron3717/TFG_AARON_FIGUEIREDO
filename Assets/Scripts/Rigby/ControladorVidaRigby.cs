using UnityEngine;
using TMPro; // Importa la librer�a de TextMesh Pro

public class ControladorVidaRigby : MonoBehaviour
{
    public static ControladorVidaRigby instance;
    public int VidaActual, VidaMaxima;
    private TextMeshProUGUI textoVidaActual; // Cambia el tipo de la variable a TextMeshProUGUI

    private void Awake()
    {
        instance = this;
        // Encuentra el objeto de texto por su nombre y asigna su componente TextMeshProUGUI
        textoVidaActual = GameObject.Find("Texto Vidas").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        VidaActual = 3; // Establece la vida actual en 3
        VidaMaxima = 10; // Establece la vida m�xima en 10
        ActualizarTextoVida(); // Actualiza el texto inicialmente
    }

    void Update()
    {

    }

    public void InfligirDa�o()
    {
        VidaActual--;
        if (VidaActual <= 0)
        {
            gameObject.SetActive(false);
        }
        ActualizarTextoVida(); // Llama a la funci�n para actualizar el texto
    }

    void ActualizarTextoVida()
    {
        if (textoVidaActual != null)
        {
            textoVidaActual.text = " X " + VidaActual.ToString();
        }
        else
        {
            Debug.LogWarning("El objeto de texto 'Texto Vidas' no se encontr� o no tiene el componente TextMeshProUGUI asignado.");
        }
    }
}
