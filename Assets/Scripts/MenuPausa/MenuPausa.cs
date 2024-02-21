using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public string elegirNivel, escena1;
    public GameObject Pausa;
    public bool isPausa;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButton("Menu"))
        {
            PausaEnPausa();
            Debug.Log("Escape a sido presionado");
        }
    }
    public void PausaEnPausa()
        //sirve para que el tiempo no siga corriendo al pausar
    { 
        if (isPausa)
        {
            isPausa = false;
            Pausa.SetActive(false);
            Time.timeScale = 1f;  
        }
        else
        {
            isPausa = true;
            Pausa.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void ElegirNivel()
    {
        SceneManager.LoadScene(elegirNivel);
    }
    public void Menu()
    {
        SceneManager.LoadScene(escena1);
    }
}
