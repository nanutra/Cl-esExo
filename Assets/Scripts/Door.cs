using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour , IDoor
{
    [SerializeField, Tooltip("clé nécessaire")] private KeyType m_neededKey;
    [SerializeField, Tooltip("animation porte")] private Animator m_animator;
    private int m_openHash;
    [SerializeField] private string m_openTriggerName = "open";

    private void Awake()
    {
        if (m_animator == null)
        {
            m_animator = GetComponent<Animator>();

            if(m_animator == null)
            {
                Debug.Log("met un animator gros bouf");
                throw new System.ArgumentNullException();
            }
        }
        m_openHash = Animator.StringToHash(m_openTriggerName);

        if(m_neededKey != null)
        {
            GetComponent<Renderer>().material =  m_neededKey.keyMat;
        }
    }


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
            m_animator?.SetTrigger(m_openHash);
        }
        
        //si le joueur n'a pas la clé on return
        /*
        Debug.Log("je n'ai pas la clé");
        return;
        /**/
    }
    
    
    
}
