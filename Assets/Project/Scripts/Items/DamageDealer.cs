using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

    public float damage;
    private PlayerHealth _playerHealth;

    public void OnTriggerEnter2D(Collider2D p_collider)
    {
        if (p_collider.tag == "Player")
        {
            if (_playerHealth == null) _playerHealth = p_collider.GetComponent<PlayerHealth>();
            _playerHealth.DamageUnit(damage);
        }
    }

}
