using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleBehavior : MonoBehaviour {
	float x = 0;
	float y = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		x = x + Input.GetAxis("Mouse X")*1.5f;
		y = y - Input.GetAxis("Mouse Y")*1.5f;

		var rotation = Quaternion.Euler(y, x, 0);

		transform.rotation = rotation;
	}
}
