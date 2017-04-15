using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour {

    public event Action<int> onHasKey;

    public int requiredKey;

    public void Open()
    {
        gameObject.SetActive(false);
    }
}
