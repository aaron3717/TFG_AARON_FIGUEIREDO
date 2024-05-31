using UnityEngine;

public class ZonaVictoria : MonoBehaviour
{
    public GameObject nivelCompletadoText;
    public Tiempo tiemposcript;

    void OnTriggerEnter2D(Collider2D other)
    {
        AudioManager.instance.StopMusic();
        if (other.CompareTag("Player"))
        {
            RigbyController playerController = other.GetComponent<RigbyController>();

            if (playerController != null)
            {
                playerController.ActivarAnimacionVictoria();
                nivelCompletadoText.SetActive(true);
                GetComponent<Collider2D>().enabled = false;
            }

            if (tiemposcript != null)
            {
                tiemposcript.DetenerContador();
                Debug.Log("Deteniendo contador desde ZonaVictoria");
            }

            Debug.Log("Zona de victoria tocada por el jugador.");
        }
    }
}
