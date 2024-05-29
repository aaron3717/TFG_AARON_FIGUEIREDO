using UnityEngine;
using System.Collections;
public class DañoEnemigo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
           
            Animator enemigoAnimator = other.GetComponent<Animator>();

            if (enemigoAnimator != null)
            {
                enemigoAnimator.Play("morir");
            }

            RigbyController.instance.Rebote();
            StartCoroutine(DesactivarEnemigo(other.gameObject, 0.5f));
        }
    }

    private IEnumerator DesactivarEnemigo(GameObject enemigo, float delay)
    {
        yield return new WaitForSeconds(delay);
        enemigo.SetActive(false);
    }
}

