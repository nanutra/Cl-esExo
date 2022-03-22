using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.Rendering.RenderGraphModule;
using Random = UnityEngine.Random;

public class Foe : MonoBehaviour
{

    [SerializeField, Tooltip("layer chest")]
    private LayerMask m_playerLayer;
    
    //liste waypoint
    public List<Transform> l_path;

    private NavMeshAgent agent;

    private Transform player;

    private bool isTrigger = false;
    private bool isTriggerCam = false;
    
    private int state = 0;

    private Event m_triggeredEvent;

    private void OnEnable()
    {
        m_triggeredEvent.onTriggered += HandleTriggerEvent;
    }
    private void OnDisable()
    {
        m_triggeredEvent.onTriggered -= HandleTriggerEvent;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrigger)
        {
            agent.SetDestination(player.position);

            return;
        }
        else if (isTriggerCam)
        {
            
        }
        agent.SetDestination(l_path[state].position);
        CheckPos();
    }

    void CheckPos()
    {
        if (transform.position.x == l_path[state].position.x)
        {
            if (transform.position.z == l_path[state].position.z)
            {
                UpdatePos();
            }
        }
    }

    void UpdatePos()
    {
        state = Random.Range(0, l_path.Count - 1);

        /*state++;
        if (state > l_path.Count - 1)
        {

        }
        /**/
    }


    private void OnTriggerEnter(Collider other)
    {
                    
        if ((m_playerLayer.value &(1 << other.gameObject.layer)) >0)
        {
            isTrigger = true;
            if (other.GetComponent<Player>() != null)
            {
                player = other.gameObject.GetComponent<Transform>();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (m_playerLayer == other.gameObject.layer)
        {
            isTrigger = false;
        }
    }

    void HandleTriggerEvent(Vector3 _position)
    {
        agent.SetDestination(_position);

    }
}
