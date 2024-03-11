using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigbyController : MonoBehaviour
{
    [Header("Movimiento")]
    public float VelocidadMovimiento;
    public float VelocidadCorrer;
    private float velocidadActual; // Variable para controlar la velocidad actual.

    [Header("Salto")]
    public float fuerzaSalto;
    private bool dobleSalto;

    [Header("Componentes")]
    public Rigidbody2D rb;
    public Animator anim;

    [Header("Detectar Suelo")]
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask WhatIsGround;

    private bool corriendo = false; // Controla si el personaje está corriendo.
    private float movimientoHorizontal;
    public static RigbyController instance;

    private void Awake()
    {
        instance = this;
        // Resto del código de inicialización...
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        velocidadActual = VelocidadMovimiento; // Inicializa la velocidad actual como la velocidad de movimiento inicial.
    }

    void Update()
    {
        if (!MenuPausa.Instance.estaEnPausa) 
        {
            // Detectar movimiento horizontal.
            movimientoHorizontal = Input.GetAxis("Horizontal");

            // Control de animación de movimiento.
            if (movimientoHorizontal != 0)
            {
                anim.SetBool("Movimiento", true); // Si hay movimiento, activa la animación de "Andar".

                // Cambiar la dirección del personaje.
                if (movimientoHorizontal > 0)
                {
                    // Mover hacia la derecha.
                    transform.localRotation = Quaternion.Euler(0, 0, 0); // Sin rotación.
                }
                else if (movimientoHorizontal < 0)
                {
                    // Mover hacia la izquierda.
                    transform.localRotation = Quaternion.Euler(0, 180, 0); // Invertir la dirección en el eje Y.
                }
            }
            else
            {
                anim.SetBool("Movimiento", false); // Si no hay movimiento, desactiva la animación de "Andar".
            }

            // Control de correr.
            // Detectar si el jugador presiona la tecla Shift para correr.
            corriendo = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

            // Actualizar el parámetro "Corriendo" en el Animator.
            anim.SetBool("corriendo", corriendo);


            // Obtener la entrada de movimiento horizontal y vertical.
            float movimientoVertical = Input.GetAxis("Vertical");

            // Calcular la velocidad de movimiento en base a si está corriendo o no.
            float velocidad = corriendo ? VelocidadCorrer : VelocidadMovimiento;

            // Calcular el vector de movimiento.
            Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical) * velocidad;

            // Aplicar el movimiento al personaje.
            rb.velocity = new Vector2(movimiento.x, rb.velocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, .2f, WhatIsGround);

            if (isGrounded)
            {
                dobleSalto = true;
                anim.SetBool("EnElSuelo", true); // Activa la animación de "EnElSuelo" cuando está en el suelo.
            }
            else
            {
                anim.SetBool("EnElSuelo", false); // Desactiva la animación de "EnElSuelo" cuando no está en el suelo.
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
                    anim.SetBool("Saltar", true); // Activa la animación de salto.
                }
                else
                {
                    if (dobleSalto)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
                        dobleSalto = false;
                        anim.SetBool("Saltar", true); // Activa la animación de salto.
                    }
                }
            }
            else
            {
                anim.SetBool("Saltar", false); // Desactiva la animación de salto cuando no estás saltando.
            }
        }
        
    }

    void FixedUpdate()
    {
        if (!corriendo && movimientoHorizontal == 0)
        {
            // Si no se está corriendo y no hay entrada de movimiento, detener el personaje.
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
}
