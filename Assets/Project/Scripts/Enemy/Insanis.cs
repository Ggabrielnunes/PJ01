using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insanis : BaseEnemy
{
    public Animator inAnimator;
    public Collider2D inCollider;
    public float damage;
    public float damageRate;
    public AudioClip roar;

    private PlayerHealth _playerHealth;
    private Emotions _playerEmotions;

    public override void MInitialize()
    {
        base.MInitialize();
        ActivateEnemy(false);
        if (activeThreshold == 0) activeThreshold = 0.2f;
        if (inactiveThreshold == 0) inactiveThreshold = 0.4f;
    }

    public override void MUpdate()
    {
        base.MUpdate();
    }

    public override void UpdateEmotion(float p_playerMood)
    {
        if (p_playerMood < activeThreshold)
        {
            ActivateEnemy(true);
        }
        else if (p_playerMood > inactiveThreshold)
        {
            ActivateEnemy(false);
        }
    }
    

    public void OnTriggerEnter2D(Collider2D p_collider)
    {
        if (p_collider.tag == "Player")
        {
            inAnimator.SetBool("Attack", true);
            if (_playerHealth == null) _playerHealth = p_collider.GetComponent<PlayerHealth>();
            if (_playerEmotions == null) _playerEmotions = p_collider.GetComponent<Emotions>();
            InvokeRepeating("DamagePlayer", 0.1f, damageRate);
            InvokeRepeating("Roar", 0.3f, 1.3f);
        }
    }

    public void OnTriggerExit2D(Collider2D p_collider)
    {
        if (p_collider.tag == "Player")
        {
            inAnimator.SetBool("Attack", false);
            if (_playerHealth != null) _playerHealth = p_collider.GetComponent<PlayerHealth>();
            CancelInvoke("DamagePlayer");
            CancelInvoke("Roar");
        }
    }

    protected override void ActivateEnemy(bool p_activate)
    {
        inCollider.enabled = p_activate;
        inAnimator.SetBool("State", p_activate);
    }

    private void DamagePlayer()
    {
        if(_playerHealth!=null && _playerEmotions!=null)
        {
            _playerHealth.DamageUnit(damage);
            _playerEmotions.SetMood(false, 0.2f);
        }
    }

    private void Roar()
    {
        SFXManager.Instance.PlaySFX(roar);
    }
}
