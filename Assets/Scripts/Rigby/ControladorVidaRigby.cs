using UnityEngine;
using TMPro;
using System.Collections;

public class ControladorVidaRigby : MonoBehaviour
{
    public static ControladorVidaRigby instance;
    public int VidaActual = 3;
    public int VidaMaxima = 10;
    private TextMeshProUGUI textoVidaActual;
    private bool esInvulnerable = false;
    private float tiempoFinInvencibilidad;
    private Material materialOriginal; // Para almacenar el material original
    public float opacidadInvulnerable = 0.5f; // Opacidad durante la invulnerabilidad (0.5 = 50%)

    private void Awake()
    {
        instance = this;
        textoVidaActual = GameObject.Find("Texto Vidas").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        VidaActual = 3;
        ActualizarTextoVida();

        // Al inicio, guarda el material original del sprite
        materialOriginal = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        if (esInvulnerable && Time.time >= tiempoFinInvencibilidad)
        {
            esInvulnerable = false;

            // Restaura el material original cuando termina la invulnerabilidad
            GetComponent<SpriteRenderer>().material = materialOriginal;
        }

        // Resto del c�digo de Update...
    }

    public void InfligirDa�o()
    {
        if (!esInvulnerable)
        {
            VidaActual--;
            if (VidaActual <= 0)
            {
                Debug.Log("El jugador ha muerto."); // Mensaje de depuraci�n

                LevelManager.instance.RespawnPlayer();
                VidaActual = 3; 
            }
            else
            {
                // Cambiar el material del sprite para ajustar la opacidad
                Material materialNuevo = new Material(materialOriginal);
                Color colorActual = materialNuevo.color;
                colorActual.a = opacidadInvulnerable;
                materialNuevo.color = colorActual;
                GetComponent<SpriteRenderer>().material = materialNuevo;

                // Activar la animaci�n de da�o
                GetComponent<Animator>().SetBool("Da�o", true);

                // Detener la animaci�n de da�o despu�s de 1.5 segundos
                StartCoroutine(DetenerAnimacionDeDa�o(1f)); // Cambia el tiempo de espera a 1.5 segundos
            }

            ActualizarTextoVida();
            ActivarInvulnerabilidad(3f); // Cambia el tiempo de invulnerabilidad a 3 segundos
        }
    }

    private IEnumerator DetenerAnimacionDeDa�o(float espera)
    {
        yield return new WaitForSeconds(espera); // Esperar 1.5 segundos
        GetComponent<Animator>().SetBool("Da�o", false); // Desactivar la animaci�n de da�o
    }

    void ActivarInvulnerabilidad(float duracion)
    {
        esInvulnerable = true;
        tiempoFinInvencibilidad = Time.time + duracion; // Duraci�n de la invencibilidad: 3 segundos
    }

    void ActualizarTextoVida()
    {
        if (textoVidaActual != null)
        {
            textoVidaActual.text = " X " + VidaActual.ToString();
        }
        else
        {
            Debug.LogWarning("El objeto de texto 'Texto Vidas' no se encontr� o no tiene el componente TextMeshProUGUI asignado.");
        }
    }

    public void AumentarVida()
    {
        if (VidaActual < VidaMaxima)
        {
            VidaActual++;
            ActualizarTextoVida();
        }
    }
}
