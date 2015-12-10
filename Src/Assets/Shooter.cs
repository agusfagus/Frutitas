using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public float speed = 20f;
	public Rigidbody bullet;
	public Rigidbody rocket;
	public float coolDown = 1.0f;
	private GameObject cardboard;
	private GameObject camera;
	private CardboardControl cardboardControl;
	private float timer = 0;

	// Use this for initialization
	void Start () {
		cardboard = GameObject.FindGameObjectWithTag("Cardboard");
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
		cardboardControl = GameObject.Find("CardboardControlManager").GetComponent<CardboardControl>();

		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		cardboardControl.trigger.OnUp += CardboardClick;
		cardboardControl.trigger.OnDown += CardboardClick;
		cardboardControl.trigger.OnClick += CardboardClick;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			Shoot();
		}
	}

	private bool CoolingDown() {
		float elapsedTime = Time.time - timer;
		return elapsedTime < coolDown;
	}

	public void CardboardClick(object sender) {
		Shoot ();
	}

	void Shoot() {
		if (Player.lives < 1 || CoolingDown())
			return;
		Debug.Log ("SHOOT");
		timer = Time.time;
		if (Player.powerup == "triple") {
			ShootBullet (0, bullet);
			ShootBullet (-8, bullet);
			ShootBullet (8, bullet);
		} else if (Player.powerup == "rocket") {
			ShootBullet(0, rocket);
		} else {
			ShootBullet(0, bullet);
		}
	}

	private void ShootBullet(float angle, Rigidbody prefab) {
		Vector3 forward = camera.transform.forward;
		forward = Quaternion.AngleAxis(angle, camera.transform.up) * forward;
		Quaternion rotation = Quaternion.LookRotation(forward);
		Rigidbody aBullet = (Rigidbody) Instantiate (prefab, cardboard.transform.position + forward * 2.0f, rotation);
		aBullet.AddForce(forward * speed);
		Destroy (aBullet.gameObject, 10.0f);
	}
}
