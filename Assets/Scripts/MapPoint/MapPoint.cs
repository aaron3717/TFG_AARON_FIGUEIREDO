using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    public MapPoint up ,right ,left , down ;
    public bool EsNivel , Bloqueado ;
    public string NivelaCargar ,CheckNivel, NombreNivel;
    public int BilletesRecogidos ;
    public float Tiempo1;

    void Start()
    {
        if (EsNivel && NivelaCargar != null)
        {
            if (PlayerPrefs.HasKey(NivelaCargar + "_billetes"))
            {
                BilletesRecogidos = PlayerPrefs.GetInt(NivelaCargar + "_billetes");
            }
            if (PlayerPrefs.HasKey(NivelaCargar + "_time"))
            {
                Tiempo1 = PlayerPrefs.GetFloat(NivelaCargar + "_time");
            }

            Bloqueado = true;

            if (CheckNivel != null)
            {
                if (PlayerPrefs.HasKey(CheckNivel + "_unlocked"))
                {
                    if (PlayerPrefs.GetInt(CheckNivel + "_unlocked") == 1)
                    {
                        Bloqueado = false;
                    }
                }
                if (NivelaCargar == CheckNivel)
                {
                    Bloqueado = false;
                }
            }
        }
        
    }

    void Update()
    {
        
    }
}
