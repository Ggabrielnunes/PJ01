using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public event Action<int> onGetKey;

    public int _type;

    public void OnTriggerEnter2D(Collider2D p_collider)
    {
        if (onGetKey != null) onGetKey(_type);
    }
}
