using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, ILoot
{
    [SerializeField, Tooltip("clé")] private KeyType m_key;
    
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
        }
        //Loot de la clé m_key
        o_key = m_key;
        return keyFounded;
    }
}
