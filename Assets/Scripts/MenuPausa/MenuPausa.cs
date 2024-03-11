using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static MenuPausa Instance;
    public string SeleccionNivel, EscenaMenuPrincipal;
    public GameObject Pausa;
    public bool estaEnPausa;
    private bool botonesInteractuables = true;


    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetButton("Menu"))
        {
            Debug.Log("Update de MenuPausa"); // Agrega este log para verificar que la función se está ejecutando.
            PausaEnPausa();
            Debug.Log("Escape ha sido presionado");
        }
    }

    public void PausaEnPausa()
    {
        // Sirve para que el tiempo no siga corriendo al pausar
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
        Debug.Log("parar/contunar");
    }

    public void SeleccionarNivel()
    {
        SceneManager.LoadScene(SeleccionNivel);
        Time.timeScale = 1f;
        Debug.Log("seleccion de nivel");
    }

    public void MenuPrincipal()
    {
      SceneManager.LoadScene(EscenaMenuPrincipal);
        Time.timeScale = 1f;
        Debug.Log("menu principal");
    }
    public void TransicionTerminada()
    {
        // Permite que los botones sean interactuables después de la transición.
        botonesInteractuables = true;
    }
}
