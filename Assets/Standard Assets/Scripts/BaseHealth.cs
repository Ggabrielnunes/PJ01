using UnityEngine;
using System.Collections;

public class BaseHealth : MonoBehaviour {

    private IEnumerator DeactivateOnDeath(float p_seconds)
    {
        yield return new WaitForSeconds(p_seconds);
        if (gameObject.activeInHierarchy) gameObject.SetActive(false);
    }

    [SerializeField] protected float _health;
    [Tooltip("Deactivate unit X seconds after death. If set to 0, unit will not deactivate upon death")]
    [SerializeField] protected float _onDeathDeactivateTime;
    
    protected virtual void OnDeath()
    {
        if (_onDeathDeactivateTime > 0) StartCoroutine(DeactivateOnDeath(_onDeathDeactivateTime));
    }

    public virtual void Damage(float p_damage)
    {
        if (_health > 0) _health -= p_damage;
        if (_health <= 0) OnDeath();
    }

    public float GetHealth()
    {
        return _health;
    }
}
