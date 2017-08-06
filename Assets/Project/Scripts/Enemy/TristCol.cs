using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TristCol : MonoBehaviour {
    public event Action<PlayerHealth> onPlayerEnter;

    public Collider2D thisCollider;

    public void OnTriggerEnter2D(Collider2D p_collider)
    {
       if(p_collider.tag=="Player")
        {
            var __health = p_collider.GetComponent<PlayerHealth>();
            if (onPlayerEnter != null) onPlayerEnter(__health);
        }
    }

    public void ActivateCollider(bool p_activate)
    {
        thisCollider.enabled = p_activate;
    }
}
