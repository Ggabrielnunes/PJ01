using UnityEngine;
using System.Collections;

public class PlayerHealth : BaseHealth {

    public event System.Action onPushed;

    public void DamageDirect(float p_damage)
    {
        if (_health > 0)
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
        if (p_force.y > 0 && onPushed != null) onPushed();
        _rigidBody.AddForce(p_force, ForceMode2D.Impulse);
    }
}
