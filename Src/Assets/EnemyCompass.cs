using UnityEngine;
using System.Collections;

public class EnemyCompass : MonoBehaviour {

	private static Camera camera;

	// Use this for initialization
	void Start () {
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject enemy = GetClosestEnemy (transform, false);
		if (enemy != null) {
//			Debug.Log ("FOUND ENEMY");
			Vector3 viewPos = camera.WorldToViewportPoint(enemy.transform.position);
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

	public static GameObject GetClosestEnemy(Transform transform, bool onScreen) {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		ArrayList offscreenEnemies = new ArrayList();

		// Filter offscreen enemies
		foreach(GameObject enemy in enemies) {
			if(IsOnScreen(enemy) == onScreen) {
				offscreenEnemies.Add(enemy);
			}
		}
		if (offscreenEnemies.Count < 1)
			return null;

		// TODO implement closest logic
		GameObject closestEnemy = enemies[0];
		float dist = Vector3.Distance(transform.position, enemies[0].transform.position);
		
		for(var i=0;i < enemies.Length; i++) {
			var tempDist = Vector3.Distance(transform.position, enemies[i].transform.position);
			if(tempDist < dist) {
				closestEnemy = enemies[i];
				dist = tempDist;
			}
		}
		return closestEnemy;
	}
	
	private static bool IsOnScreen(GameObject enemy) {
		Vector3 viewPos = camera.WorldToViewportPoint(enemy.transform.position);
		return viewPos.x > 0 && viewPos.x < 1 && viewPos.y > 0 && viewPos.y < 1 && viewPos.z >= 0;
	}
}
