using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float TiempoParaRespawn;
    

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    IEnumerator RespawnCo()
    {
        if (RigbyController.instance != null)
        {
            RigbyController.instance.gameObject.SetActive(false);
            yield return new WaitForSeconds(TiempoParaRespawn);
            RigbyController.instance.gameObject.SetActive(true);
            RigbyController.instance.transform.position = CheckpointController.instance.respawnPoint;
            ControladorVidaRigby.instance.VidaActual = 3;
            Debug.Log("Respawned with 3 vidas en posición: " + CheckpointController.instance.respawnPoint);

        }
        else
        {
            Debug.LogError("RigbyController.instance es nulo.");
            Debug.LogError("Has Respawneado con toda la vida");

        }
    }
}