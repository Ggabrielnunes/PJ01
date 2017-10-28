using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public event System.Action onEndStage;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (onEndStage != null) onEndStage();
    }
}
