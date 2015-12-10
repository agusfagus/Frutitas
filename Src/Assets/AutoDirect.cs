using UnityEngine;
using System.Collections;

public class AutoDirect : MonoBehaviour {

	public float correction = 0.2f;
	private GameObject target;
	private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		target = EnemyCompass.GetClosestEnemy (transform, true);
		if (target != null)
			Debug.Log ("LOCKED TARGET: " + target.transform.position.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			Vector3 dir = target.transform.position - transform.position;
			Vector3 upPlane = Vector3.Cross(dir, rigidbody.velocity);
			Vector3 tangent = Vector3.Cross (dir, upPlane).normalized;
			Debug.Log ("Dir:" + dir + ", Tangent:" + tangent);
			rigidbody.AddForce(tangent * correction);
			transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
		}
	}
}
