using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NivelCompletado : MonoBehaviour
{
    public float tiempoEsperaMostrarTexto = 0.5f; // Tiempo en segundos antes de mostrar el texto.

    private Text textoNivelCompletado;
    private float tiempoTranscurrido = 0f;
    private bool mostrarTexto = false;

    private void Start()
    {
        textoNivelCompletado = GetComponent<Text>();
        textoNivelCompletado.enabled = false; // Oculta el texto al principio.
    }

    private void Update()
    {
        if (mostrarTexto)
        {
            textoNivelCompletado.enabled = true; // Muestra el texto.
        }
        else
        {
            tiempoTranscurrido += Time.deltaTime;

            if (tiempoTranscurrido >= tiempoEsperaMostrarTexto)
            {
                mostrarTexto = true;
            }
        }
    }
}
