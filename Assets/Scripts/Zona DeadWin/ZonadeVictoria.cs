
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaVictoria : MonoBehaviour
{
    public GameObject nivelCompletadoText; // Asigna el GameObject del texto de "Nivel Completado" en el Inspector.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RigbyController playerController = other.GetComponent<RigbyController>();

            if (playerController != null)
            {
                playerController.ActivarAnimacionVictoria();
                // Activa el GameObject de texto "Nivel Completado" para mostrar el mensaje.
                nivelCompletadoText.SetActive(true);
            }
        }
    }
}


