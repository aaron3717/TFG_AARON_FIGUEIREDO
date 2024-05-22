using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSPlayer : MonoBehaviour
{
    public MapPoint currentPoint;
    public float velocidadmovimiento = 10f;
    public bool CargandoNivel;
    public LSManager theManager;

    void Start()
    {

    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, velocidadmovimiento * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentPoint.transform.position) < .1f)
        {
            if (Input.GetAxisRaw("Horizontal") > .5f)
            {
                if (currentPoint.right != null && !currentPoint.right.Bloqueado)
                {
                    setSiguientePunto(currentPoint.right);
                }
            }
            if (Input.GetAxisRaw("Horizontal") < -.5f)
            {
                if (currentPoint.left != null && !currentPoint.left.Bloqueado)
                {
                    setSiguientePunto(currentPoint.left);
                }
            }
            if (Input.GetAxisRaw("Vertical") > .5f)
            {
                if (currentPoint.up != null && !currentPoint.up.Bloqueado)
                {
                    setSiguientePunto(currentPoint.up);
                }
            }
            if (Input.GetAxisRaw("Vertical") < -.5f)
            {
                if (currentPoint.down != null && !currentPoint.down.Bloqueado)
                {
                    setSiguientePunto(currentPoint.down);
                }
            }
            if (currentPoint.EsNivel && currentPoint.NivelaCargar != "" && !currentPoint.Bloqueado)
            {
                TransicionLS.instance.MostrarInfo(currentPoint);
                //TransicionLS.instance.MostrarNuevoPanel(currentPoint);
                if (Input.GetButtonDown("Jump"))
                {
                    CargandoNivel = true;
                    theManager.LoadLevel();
                }
            }
            if (currentPoint.EsFin )
                TransicionLS.instance.MostrarNuevoPanel(currentPoint);
            
        }
    }

    public void setSiguientePunto(MapPoint siguientePunto)
    {
        currentPoint = siguientePunto;
        TransicionLS.instance.OcultarInfo();
        TransicionLS.instance.OcultarNuevoPanel(); 
    }
}
