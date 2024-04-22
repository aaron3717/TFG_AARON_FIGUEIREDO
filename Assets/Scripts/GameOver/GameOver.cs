using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float tiempoDeEspera = 1.5f; // Tiempo de espera antes de reiniciar el nivel
    public static GameOver instance;
    public string SeleccionNivel;

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

    public void ReiniciarNivel()
    {
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SeleccionNivel);

        Debug.Log("ReiniciarNivel() llamado.");
    }

    public void MenuPrincipal()
    {
        // Carga la escena del menú principal al activar este método
        SceneManager.LoadScene("MenuPrincipal"); // Cambia a "MenuPrincipal" con el nombre de tu escena del menú principal
    }
}
