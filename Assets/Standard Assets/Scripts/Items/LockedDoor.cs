using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour {

    public event Action<int,int> onHasKey;

    public int requiredKey;
    private int _id;

    public void SetID(int p_id)
    {
        _id = p_id;
    }

    public void OnTriggerEnter2D(Collider2D p_collider)
    {
        if (onHasKey != null) onHasKey(requiredKey,_id);
    }

    public void Open()
    {
        gameObject.SetActive(false);
    }
}
