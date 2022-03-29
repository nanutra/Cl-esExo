using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    
    [SerializeField] private Event CamEvent;
    
    [SerializeField] private Vector3 m_rot = new Vector3(0f, 0f, 1f);
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("le joueur est vu");
        CamEvent.Raise(other.transform.position);
    }

    private void Update()
    {
        transform.Rotate(m_rot);
    }
}
