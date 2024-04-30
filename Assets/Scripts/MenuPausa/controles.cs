using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour
{
    public GameObject menuPausa; // Referencia al GameObject del men� de pausa
    public GameObject panelOpciones;
    public GameObject SliderMusica;


    // M�todo para retroceder desde el panel de opciones
    public void Retroceder()
    {
        // Muestra nuevamente el men� de pausa
        menuPausa.SetActive(true);
        panelOpciones.SetActive(false);
    }
    public void Musica()
    {
        panelOpciones.SetActive(false );
        SliderMusica.SetActive(true );
    }
}
