using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public string Nivel1 , escenaContinuar;
    public static MenuPrincipal instance;
    public GameObject BotonContinuar;


    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        if(PlayerPrefs.HasKey(Nivel1 + "_unlocked"))
        {
            BotonContinuar.SetActive(true);
        }
        else
        {
            BotonContinuar.SetActive(false);
        }
    }

    public void IniciarJuego()
    {
        Debug.Log("Iniciando");
        SceneManager.LoadScene(Nivel1);
        PlayerPrefs.DeleteAll();
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
   
}
