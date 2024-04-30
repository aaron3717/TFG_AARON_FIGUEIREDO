using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour
{
    public GameObject menuPausa; // Referencia al GameObject del menú de pausa
    public GameObject panelOpciones;
    public GameObject SliderMusica;


    // Método para retroceder desde el panel de opciones
    public void Retroceder()
    {
        // Muestra nuevamente el menú de pausa
        menuPausa.SetActive(true);
        panelOpciones.SetActive(false);
    }
    public void Musica()
    {
        panelOpciones.SetActive(false );
        SliderMusica.SetActive(true );
    }
}
