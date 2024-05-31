using UnityEngine;

public class DañoJugador : MonoBehaviour
{
    public Collider2D colliderEnemigo; // Referencia al collider del enemigo.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Obtén el componente de salud del jugador
            ControladorVidaRigby saludJugador = other.GetComponent<ControladorVidaRigby>();

            // Si el jugador tiene un componente de salud, le aplicamos daño
            if (saludJugador != null)
            {
                saludJugador.InfligirDaño(); // Llama al método RecibirDaño del jugador
            }

        }
    }
}