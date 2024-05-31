using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer srenderer;
    public Sprite cpOn, cpOff;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointController.instance.DesactivarCheckpoints();
            // Cambiar el sprite a "On" cuando se active el checkpoint
            srenderer.sprite = cpOn;
            AudioManager.instance.PlaySFX(4);
            CheckpointController.instance.SetRespawnPoint(transform.position);
            Debug.Log("Checkpoint activado en posición: " + transform.position);


        }
    }

    public void  ResetCheckpoint()
    { 
        srenderer.sprite = cpOff;
    }
}
