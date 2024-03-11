using UnityEngine;
using UnityEngine.SceneManagement;

public class ZonaDeMuerte : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Resta una vida al jugador.
            ControladorVidaRigby.instance.InfligirDaño();

            // Verifica si el jugador ha tocado un checkpoint.
            if (CheckpointController.instance != null)
            {
                // Respawn en el último checkpoint tocado.
                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                // Si no hay checkpoint, respawn al principio del nivel.
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
