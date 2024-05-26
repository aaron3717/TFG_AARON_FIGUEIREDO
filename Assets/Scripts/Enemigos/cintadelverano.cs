using UnityEngine;
using System.Collections;

public class cintadelverano : MonoBehaviour
{
    [Header("Direcci�n")]
    public Transform izquierda, derecha;
    private bool movimientoDerecha;
    private Vector2 direccion;

    [Header("Movimiento")]
    public float velocidadMovimiento;
    public float tiempoEspera;
    private float contadorEspera;

    [Header("Rebote")]
    public float fuerzaRebote = 10f;

    [Header("CintaDelVerano")]
    private Rigidbody2D rb;
    public SpriteRenderer sr;
    private Animator anim;

    [Header("Objetos")]
    public GameObject objetoDejado; // Objeto que el enemigo dejar� al morir
    public float probabilidadDejarObjeto = 0.5f; // Probabilidad de dejar el objeto (0 a 1)

    // private bool golpeadoPorJugador = false;
    public GameObject detectorColision; // Objeto auxiliar para detectar colisi�n con el jugador

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        izquierda.parent = null;
        derecha.parent = null;
        movimientoDerecha = false; // Inicialmente no se mueve hacia la derecha
        contadorEspera = tiempoEspera;
        direccion = Vector2.left; // Inicialmente se mueve hacia la izquierda
        sr.flipX = false; // Orientar el sprite hacia la izquierda
    }

    void Update()
    {
        if (contadorEspera <= 0)
        {
            // Moverse
            rb.velocity = direccion * velocidadMovimiento;
        }
        else
        {
            // Esperar
            rb.velocity = Vector2.zero;
            contadorEspera -= Time.deltaTime;
            return;
        }

        // Cambiar direcci�n si alcanza los l�mites
        if (!movimientoDerecha && transform.position.x <= izquierda.position.x)
        {
            movimientoDerecha = true;
            contadorEspera = tiempoEspera;
            direccion = Vector2.right;
            sr.flipX = true; // Restaurar la orientaci�n del sprite
        }
        else if (movimientoDerecha && transform.position.x >= derecha.position.x)
        {
            movimientoDerecha = false;
            contadorEspera = tiempoEspera;
            direccion = Vector2.left;
            sr.flipX = false; // Voltear el sprite
        }
    }

    void Morir()
    {
        // Iniciar la animaci�n de muerte
        anim.SetTrigger("morir");

        // Llamar a la corrutina para desactivar el objeto despu�s de la animaci�n
        StartCoroutine(DesaparecerDespuesDeAnimacion(anim.GetCurrentAnimatorStateInfo(0).length));
    }

    IEnumerator DesaparecerDespuesDeAnimacion(float tiempo)
    {
        // Esperar hasta que la animaci�n de muerte haya terminado
        yield return new WaitForSeconds(tiempo);

        // Desactivar el GameObject del caracol
        gameObject.SetActive(false);
        // Decidir si dejar o no el objeto
        if (Random.value < probabilidadDejarObjeto)
        {
            // Instanciar el objeto dejado en la posici�n del caracol
            Instantiate(objetoDejado, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }
    }
}
