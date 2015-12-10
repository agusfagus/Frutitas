using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public float degreesX;
	public float degreesY;
	public float degreesZ;
	public float time;
	public string sceneName;
	public float speed = 20f;
	public Texture2D fadeTex;
	GameObject camera;
	bool rotate; 
	bool clicked = false;
	bool fading = false;
	ParticleSystem particleSystem;

	void Start() {
		SetGazedAt(false);
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	public void SetGazedAt(bool gazedAt) {
		rotate = gazedAt;
		ConstantForce[] constantForces = GetComponentsInChildren<ConstantForce>();
		foreach (ConstantForce constantForce in constantForces) {
			constantForce.enabled = gazedAt;
		}
	}
	
	void Update() {
		if (clicked) {
			transform.position = Vector3.MoveTowards (transform.position, camera.transform.position, Time.deltaTime * speed);
			if(!fading && Vector3.Distance(transform.position, camera.transform.position) < 10.0f) {
				Initiate.Fade(sceneName, fadeTex, 0.95f);
				fading = true;
			}
		}
	}

	public void Click() {
		clicked = true;
		transform.parent = null;
	}

}