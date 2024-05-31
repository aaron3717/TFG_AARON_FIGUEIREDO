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
    public bool esInvulnerable = false;
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

    public void InfligirDa�o()
    {
        if (!esInvulnerable)
        {
            if (VidaActual > 0)
            {
                VidaActual--;

                if (VidaActual <= 0)
                {
                 
                    GetComponent<Animator>().SetBool("Da�o", true);
                    StartCoroutine(TransicionAGameOver());
                    


                }
                else
                {
                    Material materialNuevo = new Material(materialOriginal);
                    Color colorActual = materialNuevo.color;
                    colorActual.a = opacidadInvulnerable;
                    materialNuevo.color = colorActual;
                    GetComponent<SpriteRenderer>().material = materialNuevo;

                    GetComponent<Animator>().SetBool("Da�o", true);
                    StartCoroutine(DetenerAnimacionDeDa�o(1f));
                    AudioManager.instance.PlaySFX(6);
                }

                ActualizarTextoVida();
                ActivarInvulnerabilidad(3f);
            }
        }
    }

    IEnumerator TransicionAGameOver()
    {
        yield return new WaitForSeconds(0.5f); 

        UiController.instance.PasaraNegro(); 

       
        yield return new WaitForSeconds(1.0f); 

       
        SceneManager.LoadScene("GameOver"); 
    }

    private IEnumerator DetenerAnimacionDeDa�o(float espera)
    {
        yield return new WaitForSeconds(espera);
        GetComponent<Animator>().SetBool("Da�o", false);
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
            Debug.LogWarning("El objeto de texto 'Texto Vidas' no se encontr� o no tiene el componente TextMeshProUGUI asignado.");
        }
    }

    public void AumentarVida()
    {
        if (VidaActual < VidaMaxima)
        {
            VidaActual++;
            ActualizarTextoVida();
            AudioManager.instance.PlaySFX(0);

        }
    }
}
