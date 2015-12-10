using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	public float minVolume = 0.1F;
	public float maxVolume = 0.7F;
	public float minPan = 0.2F;
	public float maxDistance = 30f;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		Vector3 horizontalRelation = new Vector3(transform.position.x, Camera.main.transform.position.y, transform.position.z);
		Vector3 targetDir = horizontalRelation - Camera.main.transform.position;
		Vector3 forward = Camera.main.transform.forward;
		float angle = Vector3.Angle(targetDir, forward);
		int sign = Vector3.Cross(targetDir, forward).y < 0 ? -1 : 1;
		angle = sign * angle;
		float distance = Vector3.Distance (transform.position, Camera.main.transform.position);
		float range = maxVolume - minVolume;
		float distanceFactor = 1 - distance / maxDistance;
		float distanceProportion = Mathf.Max (0f, distanceFactor);
		float distanceMultiplier = 0.5f +0.5f * (float)System.Math.Tanh((distanceProportion- 0.5f)*5);
		float volume = (Mathf.Cos (angle * Mathf.Deg2Rad) + 1) * range * 0.5F;

		audioSource.volume = (volume + minVolume) * distanceMultiplier;
		float pan = - Mathf.Sin (angle * Mathf.Deg2Rad);
		audioSource.panStereo = pan * (1-minPan);
;	}
}
