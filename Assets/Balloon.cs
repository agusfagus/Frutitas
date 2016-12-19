using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

	public float force = 100f;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddForce (force * Vector3.up);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
