using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private Event CamEvent;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("le joueur est vu");
        CamEvent.Raise(other.transform.position);
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
