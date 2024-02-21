using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public string escena1;

    public void StartGame()
    {
        SceneManager.LoadScene(escena1);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting the game");
        Application.Quit(); 
    }
}
