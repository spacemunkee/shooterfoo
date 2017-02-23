using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float playerSpeed = 5f;
	public float rotationSpeed = 180f;

	// Update is called once per frame
	void Update () {
		RotationUpdate (); // rotation must come first
		MovementUpdate ();
	}

	void MovementUpdate() {
		Vector3 position = transform.position;
		Vector3 velocity = new Vector3(0, Input.GetAxis ("Vertical") * playerSpeed * Time.deltaTime, 0);
		position += transform.rotation * velocity;
		transform.position = position;
	}

	void RotationUpdate() {
		Quaternion rotation = transform.rotation;
		float z = rotation.eulerAngles.z;
		z -= Input.GetAxis ("Horizontal") * rotationSpeed * Time.deltaTime;
		rotation = Quaternion.Euler (0, 0, z);
		transform.rotation = rotation;
	}
}
