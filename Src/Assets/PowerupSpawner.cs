using UnityEngine;
using System.Collections;

public class PowerupSpawner : MonoBehaviour {
	
	public GameObject[] powerups;
	public float spawnTime = 3f;
	public float distance = 20f;
	private float timer;
	
	// Use this for initialization
	void Awake () {
		timer = Time.time + SpawnTime ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < Time.time && Player.lives > 0) { //This checks wether real time has caught up to the timer
			int index = Random.Range(0, powerups.Length);
			GameObject powerup = powerups[index];
			Instantiate(powerup, SpawnPosition(), Quaternion.identity); //This spawns the emeny
			timer = Time.time + SpawnTime(); //This sets the timer 3 seconds into the future
		}
	}
	
	private float SpawnTime() {
		return spawnTime;
	}
	
	private Vector3 SpawnPosition() {
		Vector3 position = this.transform.up * distance;
		position = Quaternion.Euler(RandomAngle(), RandomAngle(), RandomAngle()) * position;
		return position;
	}
	
	private float RandomAngle() {
		return Random.Range (0, 90);
	}
}
