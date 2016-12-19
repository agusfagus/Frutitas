using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour, IGvrGazeResponder {

	private int number;

	// Use this for initialization
	void Start () {
		number = Random.Range (1, 100);
		GetComponentInChildren<TextMesh> ().text = number.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	#region IGvrGazeResponder implementation

	public void OnGazeEnter ()
	{
		Debug.Log ("Gaze Enter");
	}

	public void OnGazeExit ()
	{
		Debug.Log ("Gaze Exit");
	}

	public void OnGazeTrigger ()
	{
		Debug.Log ("Gaze Trigger");
		Challenger.getChallenger ().onNumber (this);
	}

	#endregion

	public int GetNumber() {
		return number;
	}
}
