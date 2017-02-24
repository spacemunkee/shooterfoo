using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPointer : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		Vector3 pointerPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.rotation = Quaternion.LookRotation (Vector3.forward, pointerPosition - transform.position);
	}
}
