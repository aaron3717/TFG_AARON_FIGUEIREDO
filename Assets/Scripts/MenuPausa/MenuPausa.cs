using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static MenuPausa Instance;
    public string SeleccionNivel, EscenaMenuPrincipal;
    public GameObject Pausa;
    public GameObject panelOpciones;
    public bool estaEnPausa;

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
        // Desactiva el panel de opciones y sus botones al inicio
        //panelOpciones.SetActive(false);
    }

    public void PausaEnPausa()
    {
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
        }
    }

    public void SeleccionarNivel()
    {
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SeleccionNivel);
        Time.timeScale = 1f;
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene(EscenaMenuPrincipal);
        Time.timeScale = 1f;
    }

    public void MostrarOpciones()
    {
        // Activa el panel de opciones y desactiva el menú de pausa
        
        panelOpciones.SetActive(true);
        Pausa.SetActive(false);

        Debug.Log("Panel de opciones mostrado.");
    }
}
