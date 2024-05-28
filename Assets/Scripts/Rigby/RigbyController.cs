using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RigbyController : MonoBehaviour
{
    [Header("Movimiento")]
    public float VelocidadMovimiento;
    public float VelocidadCorrer;
    private float velocidadActual;

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
    public bool isOnPlatform;
    public Transform groundCheck;
    public LayerMask WhatIsGround;
    public LayerMask WhatIsPlatform;

    [Header("Controles")]
    public Button Izda;
    public Button Dcha;
    public Button Salto;
    public Button Correr;

    private bool mIzda = false;
    private bool mDcha = false;
    private bool corriendo = false;
    public bool PararMovimiento;

    public float movimientoHorizontal;
    public static RigbyController instance;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = -1;
        instance = this;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        velocidadActual = VelocidadMovimiento;

        // Evento de Boton
        Izda.gameObject.AddComponent<Botones>().Initialize(MovIzda, PararMovIzda);
        Dcha.gameObject.AddComponent<Botones>().Initialize(MovDcha, PararMovDcha);
        Salto.onClick.AddListener(ManejarSalto);
        Correr.onClick.AddListener(ManCorrer);
    }

    void Update()
    {
        if (!MenuPausa.Instance.estaEnPausa && !PararMovimiento)
        {
            // Detectar movimiento horizontal desde el teclado y los botones
            movimientoHorizontal = Input.GetAxis("Horizontal");
            if (mIzda)
            {
                movimientoHorizontal = -1f;
            }
            else if (mDcha)
            {
                movimientoHorizontal = 1f;
            }

            // Control de animación de movimiento.
            ActualizarAnimacionMovimiento();

            // Control de correr con teclado
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                corriendo = true;
                ActualizarAnimacionCorrer();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
            {
                corriendo = false;
                ActualizarAnimacionCorrer();
            }

            // Control de correr con botón
            ActualizarAnimacionCorrer();

            // Calcular la velocidad de movimiento en base a si está corriendo o no.
            float velocidad = corriendo ? VelocidadCorrer : VelocidadMovimiento;

            // Calcular el vector de movimiento.
            Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, 0f) * velocidad;

            // Aplicar el movimiento al personaje.
            rb.velocity = new Vector2(movimiento.x, rb.velocity.y);

            // Detectar si está en el suelo o en una plataforma.
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, .2f, WhatIsGround);
            isOnPlatform = Physics2D.OverlapCircle(groundCheck.position, .2f, WhatIsPlatform);
            ActualizarAnimacionSuelo();

            // Manejar el salto desde el teclado
            if (Input.GetButtonDown("Jump"))
            {
                ManejarSalto();
            }
        }
    }

    void FixedUpdate()
    {
        if (!corriendo && movimientoHorizontal == 0)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    // Controles Teclado + Anim
    private void ActualizarAnimacionMovimiento()
    {
        if (movimientoHorizontal != 0)
        {
            anim.SetBool("Movimiento", true);

            // Cambiar la dirección del personaje.
            if (movimientoHorizontal > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (movimientoHorizontal < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else
        {
            anim.SetBool("Movimiento", false);
        }
    }

    private void ActualizarAnimacionCorrer()
    {
        anim.SetBool("corriendo", corriendo);
    }

    private void ActualizarAnimacionSuelo()
    {
        if (isGrounded || isOnPlatform)
        {
            dobleSalto = true;
            anim.SetBool("EnElSuelo", true);
        }
        else
        {
            anim.SetBool("EnElSuelo", false);
        }
    }

    public void ActivarAnimacionVictoria()
    {
        anim.SetTrigger("victoria");
    }

    public void Rebote()
    {
        rb.velocity = new Vector2(rb.velocity.x, rebotef);
    }

    // Controles Botones
    private void ManejarSalto()
    {
        if (isGrounded || isOnPlatform)
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
            estaSaltando = true;
        }
        else
        {
            if (dobleSalto)
            {
                rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
                dobleSalto = false;
                estaSaltando = true;
            }
        }
    }

    private void ManCorrer()
    {
        corriendo = !corriendo;
        ActualizarAnimacionCorrer();
    }

    public void MovIzda(bool move)
    {
        mIzda = move;
    }

    public void MovDcha(bool move)
    {
        mDcha = move;
    }

    public void PararMovIzda()
    {
        mIzda = false;
    }

    public void PararMovDcha()
    {
        mDcha = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = collision.transform; // Para moverse con la plataforma si se está moviendo
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = null; // Despegarse de la plataforma cuando se sale de ella
        }
    }
}

// PRESIONAR BOTONES
public class Botones : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private System.Action<bool> onPointerDown;
    private System.Action onPointerUp;

    public void Initialize(System.Action<bool> onPointerDown, System.Action onPointerUp)
    {
        this.onPointerDown = onPointerDown;
        this.onPointerUp = onPointerUp;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        onPointerDown(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onPointerUp();
    }
}
