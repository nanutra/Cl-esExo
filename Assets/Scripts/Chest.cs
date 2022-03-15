using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, ILoot
{
    [SerializeField, Tooltip("clé")] private KeyType m_key;

    [SerializeField, Tooltip("animation porte")] private Animator m_animator;
    private int m_openHash;
    [SerializeField] private string m_openTriggerName = "open";

    private void Awake()
    {
        if (m_animator == null)
        {
            m_animator = GetComponent<Animator>();

            if (m_animator == null)
            {
                Debug.Log("met un animator gros bouf");
                throw new System.ArgumentNullException();
            }
        }
        if (m_key != null)
        {
            GetComponent<Renderer>().material = m_key.keyMat;
        }
        m_openHash = Animator.StringToHash(m_openTriggerName);
    }

    public bool OpenChest(out KeyType o_key)
    {
        bool keyFounded = false;
        
        if (m_key == null)
        {
            Debug.Log("pas de clé ... ");
        }
        else
        {
            keyFounded = true;
            Debug.Log($"Tu as reçu la clé {m_key}");
            m_animator?.SetTrigger(m_openHash);
        }
        //Loot de la clé m_key
        o_key = m_key;
        return keyFounded;
    }
}
