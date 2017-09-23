using UnityEngine;
using System.Collections;

public class PlayerHealth : BaseHealth {

    public event System.Action onPushed;

    public void ApplyForce(Vector2 p_force)
    {
        if (p_force.y > 0 && onPushed != null) onPushed();
        _rigidBody.AddForce(p_force, ForceMode2D.Impulse);
    }
}
