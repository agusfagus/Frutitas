using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public float initSpeed = 5f;
	public float maxSpeed = 20f;
	public float rampScore = 20f;
	public GameObject explosion;
	private GameObject cardboard;

	// Use this for initialization
	void Start () {
		cardboard = GameObject.FindGameObjectWithTag("Cardboard");
	}
	
	// Update is called once per frame
	void Update () {
		if (cardboard != null) { 
			this.transform.LookAt (cardboard.transform);
			Vector3 forward = cardboard.transform.position - transform.position;
//		this.GetComponent<Rigidbody>().AddForce(forward.normalized * Time.deltaTime * speed);
			float speed = Ramp.Interpolate (initSpeed, maxSpeed, rampScore);
			transform.position = Vector3.MoveTowards (transform.position, cardboard.transform.position, Time.deltaTime * speed);
		}
	}

	void OnCollisionEnter(Collision collision) {
		// Debug-draw all contact points and normals
		Debug.Log ("COLLISSION");
		if (collision.gameObject.tag == "Cardboard") {
			cardboard.GetComponent<Player> ().OnHit (this.gameObject);
			Destroy (this.gameObject);
			Handheld.Vibrate ();
		} else if(collision.gameObject.tag == "Bullet") {
			// Explode
			Destroy (this.gameObject);
			Destroy (collision.collider.gameObject);
			GameObject anExplosion = (GameObject) Instantiate(explosion, this.transform.position, Quaternion.identity); //This spawns the emeny
			Destroy (anExplosion, 5.0f);
			cardboard.GetComponent<Player> ().OnEnemyHit (this.gameObject);
		}
	}
}
