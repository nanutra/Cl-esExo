using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour , IDoor
{
    [SerializeField, Tooltip("clé nécessaire")] private KeyType m_neededKey;
    
    public void OpenDoor(List<KeyType> p_playerKeys)
    {
        if (m_neededKey)
        {
            if (p_playerKeys == null || !p_playerKeys.Contains(m_neededKey))
            {
                Debug.Log($"ha bah non, tu dois posséder {m_neededKey}");
                return;
            }
            
            //on va check si le joueur possede la clé
            
            Debug.Log("je m'ouvre");
            
        }
        
        //si le joueur n'a pas la clé on return
        /*
        Debug.Log("je n'ai pas la clé");
        return;
        /**/
    }
    
    
    
}
