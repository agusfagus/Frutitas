using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Challenger : MonoBehaviour {

	private Challenge challenge;
	private int score;
	private Text scoreText;

	public static Challenger getChallenger() {
		return GameObject.FindGameObjectWithTag ("Challenger").GetComponent<Challenger>();
	}

	// Use this for initialization
	void Start () {
		challenge = new PrimeChallenge ();
		scoreText = GameObject.FindGameObjectWithTag ("Score").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onNumber(Number numberObject) {
		int number = numberObject.GetNumber ();
		Debug.Log ("Number: " + number);
		if (challenge.verify (number)) {
			score++;
			Debug.Log ("Score: " + score);
			scoreText.text = score.ToString ();
		}
		Destroy (numberObject.gameObject);
	}
}
