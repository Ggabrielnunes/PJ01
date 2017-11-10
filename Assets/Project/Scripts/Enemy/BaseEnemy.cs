using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {
    
    public float activeThreshold;
    public float inactiveThreshold;    

    public virtual void MInitialize()
    {
       
    }

    public virtual void MUpdate()
    {

    }

    public virtual void UpdateEmotion(float p_playerMood)
    {
        if(p_playerMood>0)
        {
            if (p_playerMood > activeThreshold)
            {
                ActivateEnemy(true);
            }
            else if (p_playerMood < inactiveThreshold)
            {
                ActivateEnemy(false);
            }
        }
        else
        {
            if (p_playerMood < activeThreshold)
            {
                ActivateEnemy(true);
            }
            else if (p_playerMood > inactiveThreshold)
            {
                ActivateEnemy(false);
            }
        }
    }

    protected virtual void ActivateEnemy(bool p_activate)
    {

    }
}
