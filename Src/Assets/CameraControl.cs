using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public float speed = 1f;
	private CardboardControl cardboardControl;

	// Use this for initialization
	void Start () {
		cardboardControl = GameObject.Find("CardboardControlManager").GetComponent<CardboardControl>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey ("space") || cardboardControl.trigger.IsHeld()) {
			GameObject camera = GameObject.FindGameObjectWithTag ("MainCamera");
			GameObject cardboard = GameObject.FindGameObjectWithTag("Cardboard");
			Vector3 forward = camera.transform.forward;
			forward.y = 0;
			cardboard.GetComponent<Rigidbody>().AddForce(forward * speed);
		}
	}
}
