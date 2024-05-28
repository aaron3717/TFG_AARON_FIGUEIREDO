using UnityEngine;

public class DEnemigo2 : MonoBehaviour
{
    public Animator anim;
    public float velocidadCaidaMinima = -0.1f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log("Trigger Encontrado");

        if (other.CompareTag("Enemigo"))
        {
           // Debug.Log("Enemigo detectado");

            Rigidbody2D rb = GetComponentInParent<Rigidbody2D>(); 
            if (rb != null)
            {
                //Debug.Log("Rigidbody2D encontrado, velocity.y: " + rb.velocity.y);

                if (rb.velocity.y < velocidadCaidaMinima)
                {
                    Boss boss = other.GetComponent<Boss>();
                    if (boss != null)
                    {
                        //Debug.Log("Componente Boss ");
                        boss.RecibirDaño();
                        RigbyController.instance.Rebote();
                    }
                }
            }
        }
    }
}
