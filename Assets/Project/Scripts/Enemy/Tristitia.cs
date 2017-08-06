using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tristitia : BaseEnemy {

    public TristCol attackCollider;
    public float attackForce = 1f;
    public float damage;
    public int attackDirection;

    public override void MInitialize()
    {
        base.MInitialize();
        attackCollider.onPlayerEnter += delegate (PlayerHealth p_health)
        {
            p_health.ApplyForce(GetAttackForce());
            p_health.DamageUnit(damage);
        };
    }

    protected override void ActivateEnemy(bool p_activate)
    {
        attackCollider.ActivateCollider(p_activate);
    }
    
    protected Vector2 GetAttackForce()
    {
        if (attackDirection == 0)
        {
            return new Vector2(attackForce,attackForce);
        }
        else return new Vector2(-attackForce, attackForce);
    }
}
