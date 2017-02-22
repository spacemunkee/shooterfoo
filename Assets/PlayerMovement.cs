using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float playerSpeed = 5f;

	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		position.y += Input.GetAxis ("Vertical") * playerSpeed * Time.deltaTime;
		transform.position = position;
	}
}
