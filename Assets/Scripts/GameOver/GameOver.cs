using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float tiempoDeEspera = 1.5f; // Tiempo de espera antes de reiniciar el nivel
    public static GameOver instance;
    public string SeleccionNivel;
    void Start()
    {
        AudioManager.instance.StopMusic();

        AudioManager.instance.PlaySFX(8);
    }
        private void Awake()
    {
        AudioManager.instance.StopMusic();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Evita la creaci�n de instancias adicionales
        }
    }
    
    public void ReiniciarNivel()
    {
        Debug.Log("Reiniciando nivel...");
        AudioManager.instance.StopMusic();
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SeleccionNivel);
        Debug.Log("ReiniciarNivel() llamado.");
    }

    public void MenuPrincipal()
    {
        // Carga la escena del men� principal al activar este m�todo
        SceneManager.LoadScene("MenuPrincipal"); // Cambia a "MenuPrincipal" con el nombre de tu escena del men� principal
    }
}
