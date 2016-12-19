using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenger : MonoBehaviour {

	private Challenge challenge;
	private int score;

	public static Challenger getChallenger() {
		return GameObject.FindGameObjectWithTag ("Challenger").GetComponent<Challenger>();
	}

	// Use this for initialization
	void Start () {
		challenge = new PrimeChallenge ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onNumber(int number) {
		Debug.Log ("Number: " + number);
		if (challenge.verify (number)) {
			score++;
			Debug.Log ("Score: " + score);
		}
	}
}
