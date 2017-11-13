using UnityEngine;
using System.Collections;

public class PlayerHealth : BaseHealth {

    public event System.Action onPushed;

    public bool isActive = true;

    public void DamageDirect(float p_damage)
    {
        if (_health > 0 && isActive)
        {
            _health -= p_damage;
            OnDamage();
            if (_health <= 0)
            {
                OnDeath();
            }
        }
    }

    public void ApplyForce(Vector2 p_force)
    {
        if(isActive)
        {
            if (p_force.y > 0 && onPushed != null) onPushed();
            _rigidBody.AddForce(p_force, ForceMode2D.Impulse);
        }
    }
}
