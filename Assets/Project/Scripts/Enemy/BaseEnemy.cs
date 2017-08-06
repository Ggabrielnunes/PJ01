using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {

    public enum emotion
    {
        RAGE,
        HAPPY,
        SAD
    }
    
    public emotion mainEmotion;
    public float activeThreshold;
    public float inactiveThreshold;    

    public virtual void MInitialize()
    {
       
    }

    public virtual void MUpdate()
    {

    }

    public void UpdateEmotion(float[] p_playerEmotions)
    {
        if(p_playerEmotions[(int)mainEmotion]>activeThreshold)
        {
            ActivateEnemy(true);
        }
        else if (p_playerEmotions[(int)mainEmotion]<inactiveThreshold)
        {
            ActivateEnemy(false);
        }
    }

    protected virtual void ActivateEnemy(bool p_activate)
    {

    }
}
