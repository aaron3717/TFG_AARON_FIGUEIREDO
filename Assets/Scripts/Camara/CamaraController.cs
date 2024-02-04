using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform jugador;
    public Transform Lejos, Medio, Cerca;
    public float ajusteX = 0.0f; // Nuevo parámetro para ajuste en el eje X
    private Vector2 ultimaPos;

    void Start()
    {
        ultimaPos = transform.position;
    }

    void Update()
    {
        float nuevaPosicionX = jugador.position.x + ajusteX; // Ajusta la posición en X
        transform.position = new Vector3(nuevaPosicionX, transform.position.y, transform.position.z);

        Vector2 amountToMove = new Vector2(transform.position.x - ultimaPos.x, transform.position.y - ultimaPos.y);
        Lejos.position = Lejos.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
        Medio.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * 0.5f;
        Cerca.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * 1.0f;
        ultimaPos = transform.position;
    }
}
