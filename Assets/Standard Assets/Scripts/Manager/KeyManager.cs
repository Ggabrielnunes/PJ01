using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour {

    public event Action<int> onGotKey;
    public event Action<int> onUsedKey;

    public Key[] keyList;
    public LockedDoor[] doorList;
    private bool[] _hasKey;

	public void KInitialize()
    {
        _hasKey = new bool[3];
        for(int i = 0; i < keyList.Length; i++)
        {
            keyList[i].onGetKey += delegate (int p_key)
              {
                  _hasKey[p_key] = true;
                  if (onGotKey != null) onGotKey(p_key);
              };
        }
        for(int i = 0; i < doorList.Length; i++)
        {
            doorList[i].onHasKey += delegate (int p_key)
              {
                  if (_hasKey[p_key])
                  {
                      doorList[i].Open();
                      UseKey(p_key);
                  }
              };
        }
    }

    private void UseKey(int p_key)
    {
        _hasKey[p_key] = false;
        if (onUsedKey != null) onUsedKey(p_key);
    }
}
