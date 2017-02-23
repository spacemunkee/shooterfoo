using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	private enum SpawnState { SPAWNING, WAITING, COUNTING }

	[System.Serializable]
	public class Wave {
		public string name;
		public Transform enemy;
		public int count;
		public float rate;
	}

	public Wave[] waves;
	public Transform[] spawnPoints;
	public float timeBetweenWaves = 5f;
	public float waveCountdown;

	private int nextWave = 0;
	private SpawnState state = SpawnState.COUNTING;
	private float searchCountdown = 1f;

	void Start() {
		waveCountdown = timeBetweenWaves;
	}

	void Update() {

		if (state == SpawnState.WAITING) {
			if (!EnemyIsAlive ()) {
				WaveCompleted ();
			} else {
				return;
			}
		}

		if (waveCountdown <= 0) {
			if (state != SpawnState.SPAWNING) {
				Debug.Log ($"nextWave = {nextWave}");
				StartCoroutine(SpawnWave(waves[nextWave]));
			}
		} else {
			waveCountdown -= Time.deltaTime;
		}
	}

	void WaveCompleted() {
		Debug.Log ("Wave Completed!");

		state = SpawnState.COUNTING;
		waveCountdown = timeBetweenWaves;

		if (nextWave + 1 > waves.Length - 1) {
			nextWave = 0;
			Debug.Log ("ALL WAVES COMPLETED! Looping...");
		} else {
			nextWave++;
		}
	}

	bool EnemyIsAlive() {
		searchCountdown -= Time.deltaTime;
		if (searchCountdown <= 0f) {
			searchCountdown = 1f;
			if (GameObject.FindGameObjectsWithTag ("Enemy") == null) {
				return false;
			}
		}

		return true;
	}

	IEnumerator SpawnWave(Wave wave) {
		state = SpawnState.SPAWNING;

		for (int i = 0; i < wave.count; i++) {
			SpawnEnemy (wave.enemy);
			yield return new WaitForSeconds (1f / wave.rate);
		}

		state = SpawnState.WAITING;

	 	yield break;
	}

	void SpawnEnemy(Transform enemy) {
		Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

		Instantiate (enemy, spawnPoint.position, spawnPoint.rotation);
		Debug.Log ($"Spawning enemy {enemy.name}");
	}
}
