using UnityEngine;
using System.Collections;

public class PlayerHealth : BaseHealth {
    private float _sanityLevel = 100;

    public void ApplyForce(Vector2 p_force)
    {
        if(p_force.y>0)
        {
            GetComponent<PlayerMovement>().toss = true;
        }
        _rigidBody.AddForce(p_force, ForceMode2D.Impulse);
    }
    
    public float GetSanity()
    {
        return _sanityLevel;
    }    
}
