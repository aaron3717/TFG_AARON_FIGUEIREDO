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
        PanelOpciones.SetActive(true);
        Pausa.SetActive(false);
    }

    //SALIR DE LOS MENUS 
    public void Retroceder()
    {
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
