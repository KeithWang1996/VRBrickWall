using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraRotate : MonoBehaviour {
	float x = 0;
	float y = 0;
	float count = 2;
	float count2 = 2;
    float force_count = 20;
	GameObject pretarget;
	Vector3 pre_position;
	GameObject reticle;
	Color pretexture;
	Image reticle_image;
	// Use this for initialization
	void Start () {
		reticle = GameObject.FindGameObjectWithTag ("reticle");
		reticle_image = reticle.GetComponent<Image> ();
		reticle_image.fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Rigidbody body;
		/*/mouse control for test
		x = x + Input.GetAxis("Mouse X")*1.5f;
		y = y - Input.GetAxis("Mouse Y")*1.5f;

		var rotation = Quaternion.Euler(y, x, 0);

		transform.rotation = rotation;
		*///mouse control end

		Vector3 fwd = transform.TransformDirection(Vector3.forward);


		if (Physics.Raycast (transform.position, fwd, out hit, 100)) {
			//print ("There is something in front of the object!");
			GameObject target = hit.collider.gameObject;
			body = target.GetComponent<Rigidbody> ();

			//float cos = Vector3.Dot(fwd, Vector3.up)/(fwd.magnitude);

			if (target.name == "Ground") {
                if(pretarget != null)
				    pretarget.GetComponent<Renderer> ().material.shader = Shader.Find ("Standard");
				Vector3 new_position = hit.point;
				if (Vector3.Angle(new_position-transform.position,pre_position- transform.position) < 1) {
					count2 -= Time.deltaTime;
					reticle_image.fillAmount = (2.0f - count2) / 2.0f;
				} else {
					count2 = 2;
					reticle_image.fillAmount = 0;
                    pre_position = new_position;
                }
				if (count2 <= 0) {
					new_position.y = 0;
					transform.parent.position = new_position;
				}
			} else {

				if (target == pretarget) {
					count -= Time.deltaTime;
					reticle_image.fillAmount = (2.0f - count) / 2.0f;
				} else {
					count = 2;
                    force_count = 20;
					reticle_image.fillAmount = 0;
					if (body != null)
						target.GetComponent<Renderer> ().material.shader = Shader.Find ("Diffuse");
					if (pretarget != null)
						pretarget.GetComponent<Renderer> ().material.shader = Shader.Find ("Standard");
				}

				if (count <= 0) {
					if (target.name == "Reset") {
						SceneManager.LoadScene ("brickwall");
					} else if (body != null) {
						fwd.y = 0;
						body.AddForce (fwd * force_count, ForceMode.Force);
                        force_count = force_count + 3f;
					}
				}
			}
			/*
			if (target.name == "Reset") {
				SceneManager.LoadScene("brickwall");
			}

			if (body != null) {
				if (count <= 0) {
					fwd.y = 0;
					body.AddForce (fwd*6500, ForceMode.Force);
				}
			}*/
			pretarget = target;
			//body.AddForce (fwd*5, ForceMode.Impulse);
		} else {
			count = 2;
            force_count = 20;
            reticle_image.fillAmount = 0;
            pretarget.GetComponent<Renderer>().material.shader = Shader.Find("Standard");
            pretarget = null;
		}
	}
}
