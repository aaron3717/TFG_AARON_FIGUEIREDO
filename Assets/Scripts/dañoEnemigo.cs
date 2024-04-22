using UnityEngine;

public class DañoEnemigo : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            // Instanciamos la animación en la posición del enemigo
            Animator animInstance = Instantiate(anim, other.transform.position, other.transform.rotation);
            animInstance.Play("morir");
            RigbyController.instance.Rebote();


            // Desactivamos el GameObject del enemigo
            other.gameObject.SetActive(false);


        }
        //if (other.CompareTag("Player"))
       // {
            // Obtén el componente de salud del jugador
          //  ControladorVidaRigby saludJugador = other.GetComponent<ControladorVidaRigby>();

            // Si el jugador tiene un componente de salud, le aplicamos daño
           // if (saludJugador != null)
           // {
            //    saludJugador.InfligirDaño(); // Llama al método RecibirDaño del jugador
            //}
        //}
    }
}
