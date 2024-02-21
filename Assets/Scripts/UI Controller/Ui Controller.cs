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



    private void Awake()
    {
        instance = this; 
    
    }
    void Start()
    {
       
    }

    void Update()
    {
        
    }
}
