using UnityEngine;
using System.Collections;

public class Prueba : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidadMovimiento;
    public float tiempoEspera;
    private float contadorEspera;

    [Header("Boss")]
    private Rigidbody2D rb;
    public SpriteRenderer sr;
    private Animator anim;

    [Header("Márgenes")]
    public float margenIzquierda;
    public float margenDerecha;

    private bool moviendoDerecha = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        contadorEspera = tiempoEspera;
        sr.flipX = false; 
    }

    void Update()
    {
        if (contadorEspera <= 0)
        {
            // Moverse horizontalmente
            if (moviendoDerecha)
            {
                rb.velocity = Vector2.right * velocidadMovimiento;
                if (transform.position.x >= margenDerecha)
                {
                    moviendoDerecha = false;
                    sr.flipX = false; 
                    contadorEspera = tiempoEspera; // Reinicia el contador de espera
                }
            }
            else
            {
                rb.velocity = Vector2.left * velocidadMovimiento;
                if (transform.position.x <= margenIzquierda)
                {
                    moviendoDerecha = true;
                    sr.flipX = true; 
                    contadorEspera = tiempoEspera; 
                }
            }
        }
        else
        {
            // Esperar
            rb.velocity = Vector2.zero;
            contadorEspera -= Time.deltaTime;
        }
    }
}
