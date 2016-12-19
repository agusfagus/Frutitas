using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour {

	public float tickTime = 5.0f;
	public GameObject balloonPrefab;

	private float nextActionTime = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextActionTime ) {
			nextActionTime += tickTime;
			Debug.Log ("Repeat");
			Vector3 position = new Vector3 (7, 1, 0);
			position = Quaternion.Euler(0, Random.Range(0, 360), 0) * position;
			GameObject ballon = (GameObject) Instantiate(balloonPrefab, position, Quaternion.identity);
		}
	}
}
