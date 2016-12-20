using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

	public AudioClip destroyClip;
	public AudioClip createClip;

	public Material[] materials;
	private static int HEIGHT_LIMIT = 15;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material = materials[Random.Range(0,materials.Length)];
		SoundManager.Instance ().play (createClip);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > HEIGHT_LIMIT || transform.position.y < -5) {
			Destroy (gameObject);
		}
	}

	void OnDestroy() {
		SoundManager.Instance ().play (destroyClip);
	}
}
