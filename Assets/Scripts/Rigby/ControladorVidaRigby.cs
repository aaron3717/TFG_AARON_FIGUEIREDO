using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControladorVidaRigby : MonoBehaviour
{
    public static ControladorVidaRigby instance;
    public int VidaActual = 3;
    public int VidaMaxima = 10;
    private TextMeshProUGUI textoVidaActual;
    private bool esInvulnerable = false;
    private float tiempoFinInvencibilidad;
    private Material materialOriginal;
    public float opacidadInvulnerable = 0.5f;

    private void Awake()
    {
        instance = this;
        textoVidaActual = GameObject.Find("Texto Vidas").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        VidaActual = 3;
        ActualizarTextoVida();
        materialOriginal = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        if (esInvulnerable && Time.time >= tiempoFinInvencibilidad)
        {
            esInvulnerable = false;
            GetComponent<SpriteRenderer>().material = materialOriginal;
        }
    }

    public void InfligirDaño()
    {
        if (!esInvulnerable)
        {
            if (VidaActual > 0)
            {
                VidaActual--;

                if (VidaActual <= 0)
                {
                    // El jugador ha perdido todas las vidas, carga la escena de Game Over
                    //SceneManager.LoadScene("GameOver"); // Reemplaza "GameOver" con el nombre de tu escena de Game Over
                    GetComponent<Animator>().SetBool("Daño", true);
                    StartCoroutine(TransicionAGameOver());

                }
                else
                {
                    Material materialNuevo = new Material(materialOriginal);
                    Color colorActual = materialNuevo.color;
                    colorActual.a = opacidadInvulnerable;
                    materialNuevo.color = colorActual;
                    GetComponent<SpriteRenderer>().material = materialNuevo;

                    GetComponent<Animator>().SetBool("Daño", true);
                    StartCoroutine(DetenerAnimacionDeDaño(1f));
                }

                ActualizarTextoVida();
                ActivarInvulnerabilidad(3f);
            }
        }
    }

    IEnumerator TransicionAGameOver()
    {
        yield return new WaitForSeconds(0.5f); // Espera medio segundo antes de la transición

        UiController.instance.PasaraNegro(); // Inicia la transición a negro

        // Espera un tiempo breve antes de cargar la escena Game Over
        yield return new WaitForSeconds(1.0f); // Ajusta el tiempo de espera según tus preferencias

        // Carga la escena de Game Over
        SceneManager.LoadScene("GameOver"); // Reemplaza "GameOver" con el nombre de tu escena de Game Over
    }

    private IEnumerator DetenerAnimacionDeDaño(float espera)
    {
        yield return new WaitForSeconds(espera);
        GetComponent<Animator>().SetBool("Daño", false);
    }

    void ActivarInvulnerabilidad(float duracion)
    {
        esInvulnerable = true;
        tiempoFinInvencibilidad = Time.time + duracion;
    }

    void ActualizarTextoVida()
    {
        if (textoVidaActual != null)
        {
            textoVidaActual.text =  VidaActual.ToString();
        }
        else
        {
            Debug.LogWarning("El objeto de texto 'Texto Vidas' no se encontró o no tiene el componente TextMeshProUGUI asignado.");
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
