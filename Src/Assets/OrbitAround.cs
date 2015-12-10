using UnityEngine;
using System.Collections;

public class OrbitAround : MonoBehaviour {

	public float initSpeed = 20f;
	public float maxSpeed = 75f;
	public float rampScore = 20f;
	private GameObject cardboard;
	
	// Use this for initialization
	void Start () {
		cardboard = GameObject.FindGameObjectWithTag("Cardboard");
	}
	
	// Update is called once per frame
	void Update () {
		float speed = Ramp.Interpolate (initSpeed, maxSpeed, rampScore);
		transform.RotateAround( cardboard.transform.position, Vector3.up, speed * Time.deltaTime );;
	}
}
