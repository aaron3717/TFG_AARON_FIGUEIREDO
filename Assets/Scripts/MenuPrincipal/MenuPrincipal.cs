using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuPrincipal : MonoBehaviour
{
    public string escenaContinuar, LS;
    public GameObject escenaInicio;
    public GameObject fondo2;
    public static MenuPrincipal instance;
    public GameObject BotonContinuar;
    


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
       
    }

    public void IniciarJuego()
    {
        Debug.Log("Iniciando");
        StartCoroutine(IniciarJuegoConTransicion());
    }
    IEnumerator IniciarJuegoConTransicion()
    {
        // Desactivar el fondo2
        if (fondo2 != null)
        {
            fondo2.SetActive(false);
        }
        else
        {
            Debug.LogError("No se ha asignado el GameObject de fondo2 en el inspector.");
            yield break;
        }

        // Activar el GameObject de escenaInicio (que ahora es un video)
        if (escenaInicio != null)
        {
            escenaInicio.SetActive(true);
            Debug.Log("EscenaInicio (video) activada.");
        }
        else
        {
            Debug.LogError("No se ha asignado el GameObject de escenaInicio en el inspector.");
            yield break;
        }

        // Esperar unos segundos antes de cargar la escena LS
        yield return new WaitForSeconds(80.0f);

        // Cargar la escena LS
        SceneManager.LoadScene(LS);

        // Limpiar PlayerPrefs (o realizar cualquier otra lógica necesaria)
        PlayerPrefs.DeleteAll();

        // Activar nuevamente el fondo2 después de cargar la escena
        //if (fondo2 != null)
        //{
         ///   fondo2.SetActive(true);
        //}
    }

    public void Continuar()
    {
        Debug.Log("Continuando");
        SceneManager.LoadScene(escenaContinuar);
    }

    public void SalirJuego()
    {
        Debug.Log("Saliendo del juego");
        Application.Quit();
    }
    public void SaltarVideo()
    {
        if (escenaInicio != null)
        {
            escenaInicio.SetActive(false); // Desactivar el video
        }
        else
        {
            Debug.LogError("No se ha asignado el GameObject de escenaInicio en el inspector.");
            return;
        }

        SceneManager.LoadScene(LS); // Cargar la escena de selección de nivel
        PlayerPrefs.DeleteAll();
    }
}
