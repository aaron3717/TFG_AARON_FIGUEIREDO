using UnityEngine;

public class Destructor : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidad de movimiento del jefe
    public int maxHealth = 10;  // Vida máxima del jefe
    public GameObject player;  // Referencia al jugador
    public GameObject deathEffect;  // Efecto de muerte (puede ser una animación)
    public GameObject dropItem;  // Objeto que deja al morir

    private int currentHealth;
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        // Moverse hacia el jugador
        if (player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Reproducir animación de muerte
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        // Instanciar el objeto que deja al morir
        if (dropItem != null)
        {
            Instantiate(dropItem, transform.position, Quaternion.identity);
        }

        // Destruir el jefe después de la animación
        Destroy(gameObject, 0.5f);  // Ajustar el tiempo para que coincida con la duración de la animación
    }

   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Quitar una vida al jugador (suponiendo que el jugador tiene un script con el método TakeDamage)
            collision.gameObject.GetComponent<Player>().TakeDamage(1);
        }
    }*/
}
