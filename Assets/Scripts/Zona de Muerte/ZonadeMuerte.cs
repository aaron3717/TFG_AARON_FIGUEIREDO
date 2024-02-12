using UnityEngine;

public class ZonaDeMuerte : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Restar una vida al jugador
            ControladorVidaRigby.instance.InfligirDaño();

            // Respawnea al jugador en el último punto de control (checkpoint) activado
            LevelManager.instance.RespawnPlayer();
        }
    }
}
