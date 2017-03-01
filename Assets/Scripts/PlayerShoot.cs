using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public GameObject shotPrefab;
	public float shootRate = 0.25f;
	float countdownTimer = 0f;

	void Update () {
		countdownTimer -= Time.deltaTime;

		if (Input.GetMouseButton (0) && countdownTimer <= 0) {
			countdownTimer = shootRate;
			Debug.Log ("Pew");
			Vector3 offset = transform.rotation * new Vector3 (0, 0.5f, 0);

			Instantiate (shotPrefab, transform.position + offset, transform.rotation);
		}
	}
}
