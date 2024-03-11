using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public static UiController instance;
    public Image Vida;
    public TMP_Text contadorBilletes;
    public Image Transicion;
    public float VelocidadTransicion = 2f ;
    private bool pasaranegro, pasarablanco;

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
            if(Transicion.color.a == 1f)
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
}
