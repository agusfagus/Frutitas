using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour {

	public Transform originObject;
	public float tickTime = 5.0f;

	private float nextActionTime = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextActionTime ) {
			nextActionTime += tickTime;
			Debug.Log ("Repeat");
		}
	}
}
