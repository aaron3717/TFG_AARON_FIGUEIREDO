using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool isBillete, isCura;
    public bool isRecogido;
    private ControladorVidaRigby controladorVida; // Variable para almacenar la referencia
    public static UiController instance;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isRecogido)
        {
            if (isBillete)
            {
                LevelManager.instance.BilletesRecogidos++;
                // Actualiza el texto del contador de billetes
                UiController.instance.contadorBilletes.text = LevelManager.instance.BilletesRecogidos.ToString() + "$";

            }
            else if (isCura)
            {
                ControladorVidaRigby.instance.AumentarVida();
            }

            isRecogido = true;
            Destroy(gameObject);
        }
    }
}
