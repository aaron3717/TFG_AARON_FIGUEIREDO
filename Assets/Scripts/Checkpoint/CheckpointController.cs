using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;
    public Checkpoint[] checkpoints;
    public Vector3 respawnPoint;

    private void Awake()
    {
        instance = this;    
    }

    private void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
        respawnPoint = RigbyController.instance.transform.position; 
    }

    public void DesactivarCheckpoints()
    {
         for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckpoint();
        }
    }
    public void SetRespawnPoint(Vector3 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }

}
