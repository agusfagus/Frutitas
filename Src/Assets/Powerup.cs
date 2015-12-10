using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	public string name;
	public float duration;
	public GameObject explosion;
	private GameObject cardboard;

	// Use this for initialization
	void Start () {
		cardboard = GameObject.FindGameObjectWithTag("Cardboard");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		// Debug-draw all contact points and normals
		if(collision.gameObject.tag == "Bullet") {
			// Explode
			Destroy (this.gameObject);
			Destroy (collision.collider.gameObject);
			GameObject anExplosion = (GameObject) Instantiate(explosion, this.transform.position, Quaternion.identity); //This spawns the emeny
			Destroy (anExplosion, 5.0f);
			cardboard.GetComponent<Player> ().OnPowerup (name, duration);
		}
	}
}
