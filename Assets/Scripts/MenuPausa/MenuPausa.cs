using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuPausa : MonoBehaviour
{
    public static MenuPausa Instance;
    public string SeleccionNivel, EscenaMenuPrincipal;
    public GameObject Pausa;
    public GameObject PanelOpciones;
    public bool estaEnPausa;
    //public Slider volumenSlider;
    //public bool isSliding;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetButton("Menu"))
        {
            PausaEnPausa();
        }
    }

    void Start()
    {

    }

    public void PausaEnPausa()
    {
        AudioManager.instance.PlaySFX(7);
        if (estaEnPausa)
        {
            estaEnPausa = false;
            Pausa.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            estaEnPausa = true;
            Pausa.SetActive(true);
            Time.timeScale = 0f;
            //volumenSlider.value = AudioManager.instance.GetVolume();
        }
    }

    public void SeleccionarNivel()
    {
        AudioManager.instance.PlaySFX(7);
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SeleccionNivel);
        Time.timeScale = 1f;
    }

    public void MenuPrincipal()
    {
        AudioManager.instance.PlaySFX(7);
        SceneManager.LoadScene(EscenaMenuPrincipal);
        Time.timeScale = 1f;
    }

    public void MostrarOpciones()
    {
        AudioManager.instance.PlaySFX(7);
        PanelOpciones.SetActive(true);
        Pausa.SetActive(false);
    }
   /* public void AdjustVolume(float direction)
    {
        // Ajustar el volumen general del juego según la dirección del deslizamiento
        float volumeIncrement = 0.1f; // Incremento de volumen
        float newVolume = AudioManager.instance.GetVolume() + (direction * volumeIncrement);
        newVolume = Mathf.Clamp01(newVolume); // Asegurarse de que el volumen esté en el rango [0,1]
        AudioManager.instance.SetVolume(newVolume);
        volumenSlider.value = newVolume; // Actualizar el valor del slider
    }

    // Método para manejar cuando se comienza a deslizar el slider
    public void OnSliderPointerDown()
    {
        isSliding = true;
    }

    // Método para manejar cuando se termina de deslizar el slider
    public void OnSliderPointerUp()
    {
        isSliding = false;
    }*/


    //SALIR DE LOS MENUS 
    public void Retroceder()
    {
        AudioManager.instance.PlaySFX(7);
        Pausa.SetActive(true);
        Debug.Log("Saliendo del menú de opciones"); 

        if (PanelOpciones != null && PanelOpciones.activeSelf)
        {
            PanelOpciones.SetActive(false);
        }
        else
        {
            Debug.LogWarning("El panel de opciones no está asignado o ya está desactivado.");
        }

  
    }

}
