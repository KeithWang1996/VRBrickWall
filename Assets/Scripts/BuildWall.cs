using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWall : MonoBehaviour {
	public GameObject brick;
    ArrayList bricks;
	void Start () {
		for (float y = 0f; y <= 10; y+=0.5f) {
			for (float x = 0f; x < 360; x+=18f) {
				Vector3 position;
				float a_angle;
				float b_angle;
				if (2*y % 2 == 0) {
					a_angle = 0;
					b_angle = 90;
				} else {
					a_angle = 9;
					b_angle = 99;
				}
				position.x = 0f + 6.8f * Mathf.Sin((x+a_angle) * Mathf.Deg2Rad);
				position.y = y;
				position.z = 0f + 6.8f * Mathf.Cos((x+a_angle) * Mathf.Deg2Rad);
				Instantiate (brick, position, Quaternion.Euler(0, x+b_angle, 0));
			}
		}
	}
}
