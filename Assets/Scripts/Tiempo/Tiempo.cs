using UnityEngine;
using TMPro;

public class Tiempo : MonoBehaviour
{
    public TextMeshProUGUI tiempoText;
    public GameObject zonaVictoria;

    private float tiempo = 0f;
    private bool victoria = false;
    private bool contandoTiempo = true;

    void Start()
    {
        if (zonaVictoria != null)
        {
            zonaVictoria.GetComponent<Collider2D>().isTrigger = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !victoria)
        {
            victoria = true;
            DetenerContador();
        }
    }

    void ActualizarTextoTiempo()
    {
        if (tiempoText != null)
        {
            int minutos = Mathf.FloorToInt(tiempo / 60);
            int segundos = Mathf.FloorToInt(tiempo % 60);
            tiempoText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
    }

    public void DetenerContador()
    {
        Debug.Log("¡Victoria alcanzada en " + tiempo.ToString("F2") + " segundos!");
        contandoTiempo = false;
    }

    void Update()
    {
        if (!victoria && contandoTiempo)
        {
            tiempo += Time.deltaTime;
            ActualizarTextoTiempo();
        }
    }
}
