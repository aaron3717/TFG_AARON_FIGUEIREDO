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
            Destroy(gameObject); // Evita la creación de instancias adicionales
        }
    }
    private void Start()
    {
        // Inicia la transición de negro a transparente al cargar la escena de GameOver
        UiController.instance.PasaraNegro();
    }

    public void ReiniciarNivel()
    {
        // Agrega aquí cualquier lógica adicional que necesites antes de reiniciar el nivel, como restablecer variables, reiniciar posiciones, etc.

        // Después de realizar cualquier lógica necesaria, carga la escena actual para reiniciar el nivel
        // Carga la escena del nivel 1
        Debug.Log("ReiniciarNivel() llamado.");
        SceneManager.LoadScene("1-1");

    }

    public void MenuPrincipal()
    {
        // Carga la escena del menú principal al activar este método
        SceneManager.LoadScene("MenuPrincipal"); // Cambia a "MenuPrincipal" con el nombre de tu escena del menú principal
    }
}
