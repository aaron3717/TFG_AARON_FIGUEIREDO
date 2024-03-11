using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public string Nivel1;
    public static MenuPrincipal instance;

    public void Awake()
    {
        instance = this;
    }

    public void IniciarJuego()
    {
        SceneManager.LoadScene(Nivel1);
    }


    public void SalirJuego()
    {
        Debug.Log("Saliendo del juego");
        Application.Quit();
    }
}
