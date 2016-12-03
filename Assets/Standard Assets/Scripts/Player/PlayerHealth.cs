using UnityEngine;
using System.Collections;

public class PlayerHealth : BaseHealth {
    private float _sanityLevel = 100;
    
    public float GetSanity()
    {
        return _sanityLevel;
    }    
}
