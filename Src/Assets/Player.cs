using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class Player : MonoBehaviour {

	public static string powerup;
	public static int lives;
	public static int score;
	public int initialLives = 3;
	private GameObject gameOverPanel;
	private Text livesText;
	private Text scoreText;
	private GameObject gameOverEffects;

	// Use this for initialization
	void Start () {
		lives = initialLives;
		score = 0;
		powerup = null;
		gameOverPanel = GameObject.FindGameObjectWithTag ("GameOverPanel");
//		gameOverEffects = GameObject.FindGameObjectWithTag ("GameOverEffects");
		livesText = GameObject.FindGameObjectWithTag ("LivesText").GetComponent<Text> ();
		scoreText = GameObject.FindGameObjectWithTag ("ScoreText").GetComponent<Text> ();

		gameOverPanel.SetActive (false);
//		gameOverEffects.SetActive (false);
		UpdateLivesUI ();
		UpdateScoreUI ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnHit(GameObject enemy) {
		if (lives > 0) {
			lives -= 1;
		}
		Debug.Log ("HIT BY ENEMY " + lives);
		UpdateLivesUI ();
		if (lives == 0) {
			GameOver ();
		}
	}

	public void GameOver() {
		foreach(GameObject enemy in GameObject.FindGameObjectsWithTag ("Enemy")) {
			Destroy (enemy);
		}
		gameOverPanel.SetActive(true);
//		gameOverEffects.SetActive(true);
	}

	public void OnEnemyHit(GameObject enemy) {
		score ++;
		UpdateScoreUI ();
	}
			
	private void UpdateLivesUI() {
		livesText.text = "Lives: " + lives;
	}

	private void UpdateScoreUI() {
		scoreText.text = "Score: " + score;
	}

	public void OnPowerup(string name, float duration) {
		StartCoroutine (Powerup(name, duration));
	}

	private IEnumerator Powerup(string name, float duration) {
		powerup = name;
		Debug.Log ("Powerup: " + name);
		yield return new WaitForSeconds(duration);
		powerup = null;
		Debug.Log ("Powerup over");
	}
}
