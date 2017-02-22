using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float playerSpeed = 5f;
	public float rotationSpeed = 180f;

	// Update is called once per frame
	void Update () {
		// rotation
		Quaternion rotation = transform.rotation;
		float z = rotation.eulerAngles.z;
		z += Input.GetAxis ("Horizontal") * rotationSpeed * Time.deltaTime;
		rotation = Quaternion.Euler (0, 0, z);
		transform.rotation = rotation;

		// vertical movement
		Vector3 position = transform.position;
		position.y += Input.GetAxis ("Vertical") * playerSpeed * Time.deltaTime;
		transform.position = position;
	}
}
