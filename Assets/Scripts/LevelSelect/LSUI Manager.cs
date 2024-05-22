using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransicionLS : MonoBehaviour
{
    public static TransicionLS instance;

    public Image Transicion;
    public float VelocidadTransicion = 2f;
    private bool pasaranegro, pasarablanco;

    public GameObject LevelInfoPanel;
    public TextMeshProUGUI NombreNivel, BilletesEncontrados, Tiempo;

    public GameObject NuevoPanel; // Referencia al nuevo panel que has creado

    private void Awake()
    {
        instance = this;
        PasaraBlanco();
    }

    void Start()
    {

    }

    void Update()
    {
        if (pasaranegro)
        {
            Transicion.color = new Color(Transicion.color.r, Transicion.color.g, Transicion.color.b, Mathf.MoveTowards(Transicion.color.a, 1f, VelocidadTransicion * Time.deltaTime));
            if (Transicion.color.a == 1f)
            {
                pasaranegro = false;
            }
        }
        if (pasarablanco)
        {
            Transicion.color = new Color(Transicion.color.r, Transicion.color.g, Transicion.color.b, Mathf.MoveTowards(Transicion.color.a, 0f, VelocidadTransicion * Time.deltaTime));
            if (Transicion.color.a == 0f)
            {
                pasarablanco = false;
            }
        }
    }

    public void PasaraNegro()
    {
        pasaranegro = true;
        pasarablanco = false;

        Debug.Log("PasaraNegro llamado. Transición a negro.");
    }

    public void PasaraBlanco()
    {
        pasarablanco = true;
        pasaranegro = false;

        Debug.Log("PasaraBlanco llamado. Transición a blanco.");
    }

    public void MostrarInfo(MapPoint levelInfo)
    {
        NombreNivel.text = levelInfo.NombreNivel;
        BilletesEncontrados.text = levelInfo.BilletesRecogidos + "$";
        Tiempo.text = Mathf.Floor(levelInfo.Tiempo1) + " s";
        LevelInfoPanel.SetActive(true);
    }

    public void OcultarInfo()
    {
        LevelInfoPanel.SetActive(false);
    }

    // Método para mostrar el nuevo panel
    public void MostrarNuevoPanel(MapPoint levelInfo)
    {
        NuevoPanel.SetActive(true);
    }

    // Método para ocultar el nuevo panel
    public void OcultarNuevoPanel()
    {
        NuevoPanel.SetActive(false);
    }
}
