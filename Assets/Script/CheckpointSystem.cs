using System;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{ 
    public static CheckpointSystem Instance;
    
    public GameObject activeCheckpoint;
    public List<GameObject> checkpoints = new();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        checkpoints.Add(activeCheckpoint);
    }
    
    public GameObject SetActiveCheckpoint(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint") && !checkpoints.Contains(other.gameObject))
        {
            checkpoints.Add(other.gameObject);
            foreach (GameObject checkpoint in checkpoints)
            {
                if (checkpoint.transform.position.z > activeCheckpoint.transform.position.z)
                {
                    activeCheckpoint = checkpoint;
                    print(other.gameObject.name + " has been set as the new checkpoint.");
                }
            }
        }
    
        return activeCheckpoint;
    }

    public GameObject GetActiveCheckpoint()
    {
        return activeCheckpoint;
    }
    
}
