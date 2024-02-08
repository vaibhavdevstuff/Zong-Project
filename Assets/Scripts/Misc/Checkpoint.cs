using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(CheckpointManager.Instance)
                CheckpointManager.Instance.AddNewCheckPoint(transform);
        }
    }














}
