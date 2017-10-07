﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insanis : BaseEnemy
{
    public Animator inAnimator;
    public Collider inCollider;
    public float damage;
    public float damageRate;

    private PlayerHealth _playerHealth;

    public override void MInitialize()
    {
        base.MInitialize();
        ActivateEnemy(true);
    }

    public override void MUpdate()
    {
        base.MUpdate();
    }

    public void OnTriggerEnter2D(Collider2D p_collider)
    {
        if (p_collider.tag == "Player")
        {
            if (_playerHealth != null) _playerHealth = p_collider.GetComponent<PlayerHealth>();
            InvokeRepeating("DamagePlayer", 0.1f, damageRate);
        }
    }

    public void OnTriggerExit2D(Collider2D p_collider)
    {
        if (p_collider.tag == "Player")
        {
            if (_playerHealth != null) _playerHealth = p_collider.GetComponent<PlayerHealth>();
            CancelInvoke("DamagePlayer");
        }
    }

    protected override void ActivateEnemy(bool p_activate)
    {
        inCollider.enabled = p_activate;
        inAnimator.SetBool("State", p_activate);
    }

    private void DamagePlayer()
    {
        if(_playerHealth!=null)
        {
            _playerHealth.DamageUnit(damage);
        }
    }
}
