using UnityEngine;
using System.Collections;

public class Compass : MonoBehaviour {

	public GameObject target;
	private static Camera camera;
	
	// Use this for initialization
	void Start () {
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null && !IsOnScreen(target) && target.active) {
			//			Debug.Log ("FOUND ENEMY");
			Vector3 viewPos = camera.WorldToViewportPoint(target.transform.position);
			viewPos = viewPos - new Vector3(0.5f, 0.5f, 0);
			//			Debug.Log ("x:" + viewPos.x + ", y:" + viewPos.y + ", z:" + viewPos.z);
			viewPos *= Mathf.Sign(viewPos.z);
			viewPos.z = 0;
			float angle = Vector3.Angle(Vector3.up, viewPos);
			Vector3 cross = Vector3.Cross(Vector3.up, viewPos);
			if (cross.z < 0) angle = -angle;
			//			Debug.Log ("angle:" + angle);
			transform.localEulerAngles = new Vector3(0, 0, angle);
			GetComponentInChildren<Renderer>().enabled = true;
		} else {
			GetComponentInChildren<Renderer>().enabled = false;
		}
	}
	
	private static bool IsOnScreen(GameObject target) {
		Vector3 viewPos = camera.WorldToViewportPoint(target.transform.position);
		return viewPos.x > 0 && viewPos.x < 1 && viewPos.y > 0 && viewPos.y < 1 && viewPos.z >= 0;
	}
}
