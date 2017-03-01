﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotMovement : MonoBehaviour {

	public float speed = 5f;
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;

		Vector3 velocity = new Vector3 (0, speed * Time.deltaTime, 0);

		position += transform.rotation * velocity;

		transform.position = position;
	}
}
