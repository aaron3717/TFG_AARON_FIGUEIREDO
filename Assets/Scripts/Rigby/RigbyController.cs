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

    private bool corriendo = false; // Controla si el personaje est� corriendo.
    private float movimientoHorizontal;
    public static RigbyController instance;

    private void Awake()
    {
        instance = this;
        // Resto del c�digo de inicializaci�n...
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

            // Control de animaci�n de movimiento.
            if (movimientoHorizontal != 0)
            {
                anim.SetBool("Movimiento", true); // Si hay movimiento, activa la animaci�n de "Andar".

                // Cambiar la direcci�n del personaje.
                if (movimientoHorizontal > 0)
                {
                    // Mover hacia la derecha.
                    transform.localRotation = Quaternion.Euler(0, 0, 0); // Sin rotaci�n.
                }
                else if (movimientoHorizontal < 0)
                {
                    // Mover hacia la izquierda.
                    transform.localRotation = Quaternion.Euler(0, 180, 0); // Invertir la direcci�n en el eje Y.
                }
            }
            else
            {
                anim.SetBool("Movimiento", false); // Si no hay movimiento, desactiva la animaci�n de "Andar".
            }

            // Control de correr.
            // Detectar si el jugador presiona la tecla Shift para correr.
            corriendo = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

            // Actualizar el par�metro "Corriendo" en el Animator.
            anim.SetBool("corriendo", corriendo);


            // Obtener la entrada de movimiento horizontal y vertical.
            float movimientoVertical = Input.GetAxis("Vertical");

            // Calcular la velocidad de movimiento en base a si est� corriendo o no.
            float velocidad = corriendo ? VelocidadCorrer : VelocidadMovimiento;

            // Calcular el vector de movimiento.
            Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical) * velocidad;

            // Aplicar el movimiento al personaje.
            rb.velocity = new Vector2(movimiento.x, rb.velocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, .2f, WhatIsGround);

            if (isGrounded)
            {
                dobleSalto = true;
                anim.SetBool("EnElSuelo", true); // Activa la animaci�n de "EnElSuelo" cuando est� en el suelo.
            }
            else
            {
                anim.SetBool("EnElSuelo", false); // Desactiva la animaci�n de "EnElSuelo" cuando no est� en el suelo.
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
                    anim.SetBool("Saltar", true); // Activa la animaci�n de salto.
                }
                else
                {
                    if (dobleSalto)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
                        dobleSalto = false;
                        anim.SetBool("Saltar", true); // Activa la animaci�n de salto.
                    }
                }
            }
            else
            {
                anim.SetBool("Saltar", false); // Desactiva la animaci�n de salto cuando no est�s saltando.
            }
        }
        
    }

    void FixedUpdate()
    {
        if (!corriendo && movimientoHorizontal == 0)
        {
            // Si no se est� corriendo y no hay entrada de movimiento, detener el personaje.
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
}
