using UnityEngine;
using System.Collections;

public class RotateTarget : MonoBehaviour {
    public float xSpeed = 0;
    public float ySpeed = 1;
    public float zSpeed = 0;
	// Update is called once per frame
	void Update () {
        transform.Rotate(xSpeed, ySpeed, zSpeed);
	}
}
