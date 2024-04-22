using UnityEngine;
using System.Collections;

public class TransicionGO : MonoBehaviour
{
    public GameObject Fondo1;
    public GameObject PanelOpciones;
    public float transitionDuration = 2.0f; // Duración de la transición entre fondos
    public float timeBetweenTransitions = 3.0f; // Tiempo entre transiciones
    private int currentBackground = 1;

    void Start()
    {
        // Comenzar con el fondo 1 activado 
        Fondo1.SetActive(true);
        PanelOpciones.SetActive(false);

        StartCoroutine(StartAutomaticTransition());
    }

    IEnumerator StartAutomaticTransition()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenTransitions);

            if (currentBackground == 1)
            {
                // Desactivar el fondo 1 después de 2 segundos
                yield return new WaitForSeconds(2.0f);
                Fondo1.SetActive(true);

                // Esperar 0.5 segundos y luego activar el PanelOpciones
                yield return new WaitForSeconds(0.5f);
                PanelOpciones.SetActive(true);

                // Terminar la rutina, ya que hemos llegado a fondo 2
                yield break;
            }
        }
    }
}
