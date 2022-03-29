using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Tooltip("layer Door")]
    private LayerMask m_doorLayer;
    [SerializeField, Tooltip("layer chest")]
    private LayerMask m_chestLayer;
    
    private CharacterController charaController;
    [SerializeField, Tooltip("la vitesse")]
    private float m_speed = 4f;
    private float m_x;
    private float m_z;
    private float m_dSpeed;

    //private int 
    
    [SerializeField, Tooltip("liste des clées")]
    public List<KeyType> m_keyHolder;

    // Update is called once per frame

    private void Awake()
    {
        charaController = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {

        m_dSpeed = m_speed * Time.deltaTime;
        m_x = Input.GetAxis("Horizontal") ;
        m_z = Input.GetAxis("Vertical") ;

        Vector3 move = transform.right * m_x + transform.forward * m_z;
        
        charaController.Move(move * m_dSpeed);


    }
    
    private void OnTriggerEnter(Collider other)
    {
        if ((m_chestLayer.value & (1 << other.gameObject.layer)) >0 )
        {
            Chest myLootBox = other.gameObject.GetComponent<Chest>();
            
            if (myLootBox && myLootBox.OpenChest(out KeyType o_key))
            {
                Debug.Log("tu rentres ?");
                if (!m_keyHolder.Contains(o_key))
                {
                    Debug.Log("bravo ! ");
                    m_keyHolder.Add(o_key);
                    
                }
            }
            
        }
        else if((m_doorLayer.value &(1 << other.gameObject.layer)) >0 )
        {
            Door myDoor = other.GetComponent<Door>();
            
            if(myDoor) myDoor.OpenDoor(m_keyHolder);
        }
    }
}
