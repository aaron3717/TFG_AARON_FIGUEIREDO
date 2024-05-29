using UnityEngine;
using UnityEngine.UI; 

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial; 

    private void Start()
    {
        // mensaje  desactivado al inicio
        if (tutorial != null)
        {
            tutorial.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            // Activa el mensaje 
            if (tutorial != null)
            {
                tutorial.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Desactiva el mensaje 
            if (tutorial != null)
            {
                tutorial.SetActive(false);
            }
        }
    }
}
