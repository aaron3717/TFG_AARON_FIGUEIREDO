using UnityEngine;
using System.Collections;

public class transicion : MonoBehaviour
{
    public GameObject background1;
    public GameObject background2;
    public GameObject background3; // El fondo en negro
    public GameObject PanelOpciones;
    public float transitionDuration = 2.0f; // Duración de la transición entre fondos
    public float timeBetweenTransitions = 3.0f; // Tiempo entre transiciones
    private int currentBackground = 1;

    void Start()
    {
        // Comenzar con el fondo 1 activado y los fondos 2 y 3 desactivados
        background1.SetActive(true);
        background2.SetActive(false);
        background3.SetActive(false);
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
                background1.SetActive(false);

                // Activar el fondo 3 y esperar la duración de la transición
                background3.SetActive(true);
                yield return new WaitForSeconds(transitionDuration);

                // Desactivar el fondo 3 y activar el fondo 2
                background3.SetActive(false);
                background2.SetActive(true);
                yield return new WaitForSeconds(transitionDuration);
                PanelOpciones.SetActive(true);

                // Terminar la rutina, ya que hemos llegado a fondo 2
                yield break;
            }
            else if (currentBackground == 2)
            {

                // Activar el fondo 3 y esperar la duración de la transición
                background3.SetActive(true);
                yield return new WaitForSeconds(transitionDuration);

                // Desactivar el fondo 3
                background3.SetActive(false);
            }

            currentBackground = (currentBackground % 3) + 1;
        }
    }
}
