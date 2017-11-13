using UnityEngine;
using System.Collections;

public class BaseHealth : MonoBehaviour {

    private IEnumerator DeactivateOnDeath(float p_seconds)
    {
        yield return new WaitForSeconds(p_seconds);
        if (gameObject.activeInHierarchy) gameObject.SetActive(false);
    }

    public event System.Action<float> onDamage;
    public event System.Action<bool> onInvincible;
    public event System.Action onDeath;

    [SerializeField] protected float _health;
    [SerializeField] protected float _invincibleTimeAfterDamage;
    [Tooltip("Deactivate unit X seconds after death. If set to 0, unit will not deactivate upon death")]
    [SerializeField] protected float _onDeathDeactivateTime;
    [SerializeField] protected Rigidbody2D _rigidBody;
    private bool _invincible = false;
    
    protected virtual void OnDeath()
    {
        if (onDeath != null) onDeath();
        if (_onDeathDeactivateTime > 0) StartCoroutine(DeactivateOnDeath(_onDeathDeactivateTime));
    }

    public virtual void DamageUnit(float p_damage)
    {
        if(!_invincible)
        {
            if (_health > 0)
            {
                _health -= p_damage;
                OnDamage();
                if (_health <= 0)
                {
                    OnDeath();
                }
                else SetInvincible(true);
            }
        }
    }

    public void Kill()
    {
        _health = -10;
        OnDamage();
        OnDeath();
    }

    public virtual void SetInvincible(bool p_inv)
    {
        _invincible = p_inv;
        if (onInvincible != null) onInvincible(_invincible);
        if(_invincible)
        {
            Invoke("BackToNormal",_invincibleTimeAfterDamage);
        }
    }

    public float GetHealth()
    {
        return _health;
    }

    protected void OnDamage()
    {
        if (onDamage != null) onDamage(_health);
    }

    private void BackToNormal()
    {
        SetInvincible(false);
    }
}
