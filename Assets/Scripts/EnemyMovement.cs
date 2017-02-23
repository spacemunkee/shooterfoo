using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float velocityMin = 1f;
	public float velocityMax = 3f;
	private Vector3 velocity;

	// Use this for initialization
	void Start () {
		velocity = new Vector3 (Random.Range(velocityMin, velocityMax), Random.Range(velocityMin, velocityMax), 0);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;

		position.x += velocity.x * Time.deltaTime;
		position.y += velocity.y * Time.deltaTime;
		transform.position = position;
	}
}
