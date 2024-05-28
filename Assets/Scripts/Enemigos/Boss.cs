using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    public int saludMaxima = 3;
    private int saludActual;
    public float tiempoEspera;
    private float contadorEspera;

    [Header("Rebote")]
    public float fuerzaRebote = 10f;

    [Header("Boss")]
    private Rigidbody2D rb;
    public SpriteRenderer sr;
    private Animator anim;

    [Header("Objetos")]
    public GameObject objetoDejado; 
    public float probabilidadDejarObjeto = 0.5f; 
    public GameObject zonaVictoria; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        saludActual = saludMaxima; 
        sr.flipX = false; 
        if (zonaVictoria != null)
        {
            zonaVictoria.SetActive(false); 
        }
    }

    void Update()
    {
        if (contadorEspera <= 0)
        {
        }
        else
        {
            
            rb.velocity = Vector2.zero;
            contadorEspera -= Time.deltaTime;
            return;
        }
    }

    void Morir()
    {
        anim.SetTrigger("morir");
        StartCoroutine(DesaparecerDespuesDeAnimacion(anim.GetCurrentAnimatorStateInfo(0).length));
    }

    IEnumerator DesaparecerDespuesDeAnimacion(float tiempo)
    {
        // Esperar hasta que la animación de muerte haya terminado
        yield return new WaitForSeconds(tiempo);

        // Desactivar el GameObject del boss
        gameObject.SetActive(false);

        // Decidir si dejar o no el objeto
        if (Random.value < probabilidadDejarObjeto)
        {
            // Instanciar el objeto dejado en la posición del boss
            Instantiate(objetoDejado, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }

        // Activar la zona de victoria
        if (zonaVictoria != null)
        {
            zonaVictoria.SetActive(true);
        }
    }

    public void RecibirDaño()
    {
        saludActual--; 
        if (saludActual <= 0)
        {
            Morir(); 
        }
    }
}
