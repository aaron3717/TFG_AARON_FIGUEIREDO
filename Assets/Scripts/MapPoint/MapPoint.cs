using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    //  conectar con otros MapPoints
    public MapPoint up, right, left, down;

    // Variables de estado del punto
    public bool EsNivel, Bloqueado , EsFin;
    public string NivelaCargar, CheckNivel, NombreNivel;
    public int BilletesRecogidos;
    public float Tiempo1;
    //sprite
    public SpriteRenderer spriteRenderer;


    void Start()
    {
        // Obtener el componente SpriteRenderer si el nivel está desbloqueado
        if (!Bloqueado)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Cargar datos de PlayerPrefs si es un nivel y hay un nombre de nivel definido
        if (EsNivel && !string.IsNullOrEmpty(NivelaCargar))
        {
            // Cargar billetes recogidos y tiempo si existen
            BilletesRecogidos = PlayerPrefs.GetInt(NivelaCargar + "_billetes", 0);
            Tiempo1 = PlayerPrefs.GetFloat(NivelaCargar + "_time", 0f);

            // El nivel está bloqueado y oculto por defecto
            Bloqueado = true;

            // Verificar si el nivel está desbloqueado en PlayerPrefs
            if (!string.IsNullOrEmpty(CheckNivel))
            {
                // Si el nivel está marcado como desbloqueado, desbloquearlo y mostrarlo
                Bloqueado = PlayerPrefs.GetInt(CheckNivel + "_unlocked", 0) != 1 ? true : false;

                // Si el nivel a cargar es el mismo que el nivel de verificación, desbloquearlo y mostrarlo
                if (NivelaCargar == CheckNivel)
                {
                    Bloqueado = false;
                }
            }
        }
        if (EsFin && !string.IsNullOrEmpty(NivelaCargar))
        {
            // Cargar billetes recogidos y tiempo si existen
            BilletesRecogidos = PlayerPrefs.GetInt(NivelaCargar + "_billetes", 0);
            Tiempo1 = PlayerPrefs.GetFloat(NivelaCargar + "_time", 0f);

            // El nivel está bloqueado y oculto por defecto
            Bloqueado = true;

            // Verificar si el nivel está desbloqueado en PlayerPrefs
            if (!string.IsNullOrEmpty(CheckNivel))
            {
                // Si el nivel está marcado como desbloqueado, desbloquearlo y mostrarlo
                Bloqueado = PlayerPrefs.GetInt(CheckNivel + "_unlocked", 0) != 1 ? true : false;

                // Si el nivel a cargar es el mismo que el nivel de verificación, desbloquearlo y mostrarlo
                if (NivelaCargar == CheckNivel)
                {
                    Bloqueado = false;
                }
            }
        }

        // Verificar si hay un nivel anterior y activar su SpriteRenderer si está completado
        if (up != null && up.BilletesRecogidos > 0)
        {
            // Obtener el componente SpriteRenderer si está presente
            SpriteRenderer upSpriteRenderer = up.GetComponent<SpriteRenderer>();
            if (upSpriteRenderer != null)
                upSpriteRenderer.enabled = true;
        }

        // Activar el SpriteRenderer solo si el nivel está desbloqueado
        if (!Bloqueado && spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
        }
    }


    // Método  completar el nivel
    public void CompletarNivel()
    {
        // Guardar el progreso del nivel actual
        PlayerPrefs.SetInt(NivelaCargar + "_billetes", BilletesRecogidos);
        PlayerPrefs.SetFloat(NivelaCargar + "_time", Tiempo1);

        // Desbloquear el siguiente nivel si hay uno
        if (right != null && !string.IsNullOrEmpty(right.CheckNivel))
        {
            PlayerPrefs.SetInt(right.CheckNivel + "_unlocked", 1);
        }
    }
}