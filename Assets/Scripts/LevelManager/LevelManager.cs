using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float TiempoParaRespawn;
    public int BilletesRecogidos;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(TransicionDeInicio());
    }

    IEnumerator TransicionDeInicio()
    {
        UiController.instance.PasaraNegro();
        yield return new WaitForSeconds(1.0f); // Ajusta el tiempo de espera según tus preferencias
        UiController.instance.PasaraBlanco();
        // Continúa con la inicialización del nivel aquí
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    IEnumerator RespawnCo()
    {
        if (RigbyController.instance != null && UiController.instance != null)
        {
            UiController.instance.PasaraNegro();
            yield return new WaitForSeconds(1.0f); // Ajusta el tiempo de espera según tus preferencias

            // Verifica si el jugador ha tocado un checkpoint.
            if (CheckpointController.instance != null)
            {
                // Respawn en el último checkpoint tocado.
                RigbyController.instance.transform.position = CheckpointController.instance.respawnPoint;
            }
            else
            {
                // Si no hay checkpoint, respawn al principio del nivel.
                RigbyController.instance.transform.position = new Vector3(0f, 0f, 0f); // Ajusta la posición inicial según tu nivel.
            }

            UiController.instance.PasaraBlanco();

            // Verifica si el jugador ha perdido todas las vidas y, en ese caso, reinicia el nivel.
            if (ControladorVidaRigby.instance.VidaActual <= 0)
            {
                SceneManager.LoadScene("GameOver"); // Ajusta el nombre de la escena "GameOver".

            }
        }
    }
}
