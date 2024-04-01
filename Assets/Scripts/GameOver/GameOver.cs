using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float tiempoDeEspera = 1.5f; // Tiempo de espera antes de reiniciar el nivel
    public static GameOver instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Evita la creaci�n de instancias adicionales
        }
    }
    private void Start()
    {
        // Inicia la transici�n de negro a transparente al cargar la escena de GameOver
        UiController.instance.PasaraNegro();
    }

    public void ReiniciarNivel()
    {
        // Agrega aqu� cualquier l�gica adicional que necesites antes de reiniciar el nivel, como restablecer variables, reiniciar posiciones, etc.

        // Despu�s de realizar cualquier l�gica necesaria, carga la escena actual para reiniciar el nivel
        // Carga la escena del nivel 1
        Debug.Log("ReiniciarNivel() llamado.");
        SceneManager.LoadScene("1-1");

    }

    public void MenuPrincipal()
    {
        // Carga la escena del men� principal al activar este m�todo
        SceneManager.LoadScene("MenuPrincipal"); // Cambia a "MenuPrincipal" con el nombre de tu escena del men� principal
    }
}
