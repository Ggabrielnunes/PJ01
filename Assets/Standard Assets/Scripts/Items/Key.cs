using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public event Action<int, int> onGetKey;

    public int type;
    private int _id;

    public void SetID(int p_id)
    {
        _id = p_id;
    }

    public void OnTriggerEnter2D(Collider2D p_collider)
    {
        if (onGetKey != null) onGetKey(type,_id);
    }

    public void GotKey()
    {
        gameObject.SetActive(false);
    }
}
