using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		Cardboard.SDK.VRModeEnabled = false;
		// Disable VR
	}
	
	// Update is called once per frame
	void Update () {
//		GameObject particle = new GameObject();
//			foreach (Touch touch in Input.touches) {
//				if (touch.phase == TouchPhase.Began) {
//					// Construct a ray from the current touch coordinates
//					Ray ray = Camera.main.ScreenPointToRay (touch.position);
//					if (Physics.Raycast (ray)) {
//						// Create a particle if hit
//						Instantiate (particle, transform.position, transform.rotation);
//					}
//				}
//			}
		}

	public void PlayButton(){
		Application.LoadLevel ("Main");
 		// Disable VR
	}

	public void  CardboardButton(){
		Application.LoadLevel ("Main");
 		// Enable VR
	}
}
