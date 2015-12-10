using UnityEngine;
using System.Collections;

public class PlayButtonScript : MonoBehaviour {

	void OnTouchDown(){
		
		Application.LoadLevel ("room");
	}
	void OnTouchUp(){
		Application.LoadLevel ("room");
	}
	void OnTouchStay(){
		Application.LoadLevel ("room");
	}

}
