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
                Debug.Log("Billete recogido");
                LevelManager.instance.BilletesRecogidos++;
                // Actualiza el texto del contador de billetes
                UiController.instance.contadorBilletes.text = LevelManager.instance.BilletesRecogidos.ToString() + "$";
                AudioManager.instance.PlaySFX(1); // Sonido de billete recogido
            }
            else if (isCura)
            {
                Debug.Log("Cura recogida");
                ControladorVidaRigby.instance.AumentarVida();
                AudioManager.instance.PlaySFX(0); // Sonido de cura recogida
            }

            isRecogido = true;
            Destroy(gameObject);
        }
    }
}
