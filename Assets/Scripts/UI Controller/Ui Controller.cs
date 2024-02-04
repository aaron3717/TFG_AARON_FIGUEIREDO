using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public static UiController instance;
    public Image Vida;

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
