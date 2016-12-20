using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Challenger : MonoBehaviour {

	public GameObject correctPrefab;
	public GameObject wrongPrefab;

	private static int CHALLENGE_GOAL = 10;
	private Challenge[] challenges;
	private int currentChallenge;
	private int score;
	private Text scoreText;
	private Text shortChallengeText;
	private Text challengeText;

	public static Challenger getChallenger() {
		return GameObject.FindGameObjectWithTag ("Challenger").GetComponent<Challenger>();
	}

	// Use this for initialization
	void Start () {
		challenges = new Challenge[] {new PrimeChallenge (), new SevenChallenge()};
		scoreText = GameObject.FindGameObjectWithTag ("Score").GetComponent<Text> ();
		shortChallengeText = GameObject.FindGameObjectWithTag ("ShortChallenge").GetComponent<Text> ();
		challengeText = GameObject.FindGameObjectWithTag ("Challenge").GetComponent<Text> ();
		StartCoroutine(ShowChallenge ());
		StartCoroutine (Timer ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onNumber(Number numberObject) {
		int number = numberObject.GetNumber ();
		Debug.Log ("Number: " + number);
		if (GetChallenge().verify (number)) {
			Debug.Log ("Verified!");
			score += 2;
//			if (score > CHALLENGE_GOAL * (currentChallenge+1)) {
//				NextChallenge ();
//			}
			ShowFeedback(correctPrefab, numberObject.transform.position);
		} else {
			score -= 1;
			if (score < 0)
				score = 0;
			ShowFeedback (wrongPrefab, numberObject.transform.position);
		}
		Debug.Log ("Score: " + score);
		scoreText.text = score.ToString ();
		Destroy (numberObject.gameObject);
	}

	private Challenge GetChallenge() {
		return challenges [currentChallenge];
	}

	private void ShowFeedback(GameObject prefab, Vector3 position) {
		GameObject feedback = Instantiate(prefab, position, Quaternion.identity);
		feedback.transform.LookAt (Camera.main.transform.position);
		Destroy (feedback, 4.0f);
	}

	private void NextChallenge() {
		Debug.Log ("Next Challenge");
		currentChallenge++;
		StartCoroutine (ShowChallenge());
		if (currentChallenge >= challenges.Length) {
			StartCoroutine (GameOver());
		}
	}

	IEnumerator ShowChallenge()
	{
		shortChallengeText.text = GetChallenge ().shortMessage();
		challengeText.text = GetChallenge ().message();
		challengeText.gameObject.SetActive (true);
		shortChallengeText.gameObject.SetActive (false);
		yield return new WaitForSeconds(3);
		challengeText.gameObject.SetActive (false);
		shortChallengeText.gameObject.SetActive (true);
	}

	IEnumerator GameOver()
	{
		challengeText.text = "Game Over\nYour Score is: " + score;
		challengeText.gameObject.SetActive (true);
		shortChallengeText.gameObject.SetActive (false);
		yield return new WaitForSeconds(3);
		Scenes.Load ("Menu");
	}

	IEnumerator Timer () {
		while (currentChallenge < challenges.Length) {
			yield return new WaitForSeconds (30);
			NextChallenge ();
		}
		NextChallenge ();
	}
}
