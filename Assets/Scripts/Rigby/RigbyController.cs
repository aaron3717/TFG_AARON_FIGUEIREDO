using UnityEngine;
using System.Collections;
using UnityEngine.Device;

public class RigbyController : MonoBehaviour
{
    [Header("Movimiento")]
    public float VelocidadMovimiento;
    public float VelocidadCorrer;
    private float velocidadActual; // Variable para controlar la velocidad actual.

    [Header("Salto")]
    public float fuerzaSalto;
    private bool dobleSalto;
    public bool estaSaltando;
    public float rebotef;

    [Header("Componentes")]
    public Rigidbody2D rb;
    public Animator anim;

    [Header("Detectar Suelo")]
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask WhatIsGround;



    public bool corriendo = false; // Controla si el personaje está corriendo.
    public float movimientoHorizontal;
    public static RigbyController instance;

    public bool PararMovimiento;
   



    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        UnityEngine.Application.targetFrameRate = -1;
        instance = this;
        // Resto del código de inicialización...
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        velocidadActual = VelocidadMovimiento; 
    }

    void Update()
    {
        if (!MenuPausa.Instance.estaEnPausa && !PararMovimiento)
        {
            // Detectar movimiento horizontal.
            movimientoHorizontal = Input.GetAxis("Horizontal");

            // Control de animación de movimiento.
            if (movimientoHorizontal != 0)
            {
                anim.SetBool("Movimiento", true); 

                // Cambiar la dirección del personaje.
                if (movimientoHorizontal > 0)
                {
                    // Mover hacia la derecha.
                    transform.localRotation = Quaternion.Euler(0, 0, 0); 
                }
                else if (movimientoHorizontal < 0)
                {
                    // Mover hacia la izquierda.
                    transform.localRotation = Quaternion.Euler(0, 180, 0); 
                }
            }
            else
            {
                anim.SetBool("Movimiento", false); 
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
                    rb.velocity =  new Vector2(rb.velocity.x, fuerzaSalto);
                    estaSaltando = true; // El jugador está saltando
                    //anim.SetBool("Saltar", true); // Activa la animación de salto.
                }
                else
                {
                    if (dobleSalto)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
                        dobleSalto = false;
                        estaSaltando = true; // El jugador está saltando
                    }
                }
            }
            else if (isGrounded)
            {
                estaSaltando = false; // El jugador no está saltando
            }
        }
    
    }
    public void ActivarAnimacionVictoria()
    {
        // Activa el Trigger "Victoria" en el Animator.
        anim.SetTrigger("victoria");
    }
    public void Rebote()
    {
        rb.velocity = new Vector2(rb.velocity.x, rebotef);
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
