using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {

	public bool start = false;
	public float fadeDamp = 0.0f;
	public string fadeScene;
	public float alpha = 0.0f;
	public Color fadeColor;
	public bool isFadeIn = false;
	public Texture2D tex;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnGUI () {
		if (!start)
			return;
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
//		Texture2D tex = new Texture2D (1, 1);
//		tex.SetPixel (0, 0, fadeColor);
//		tex.Apply ();

		GUI.DrawTexture (new Rect(0, 0, Screen.width/2, Screen.height), tex);
		GUI.DrawTexture (new Rect(Screen.width/2, 0, Screen.width/2, Screen.height), tex);
		if (isFadeIn) {
			alpha = Mathf.Lerp (alpha, -0.1f, fadeDamp * Time.deltaTime);
		} else {
			alpha = Mathf.Lerp (alpha, 1.1f, fadeDamp * Time.deltaTime);
		}
//		Debug.Log (alpha);
		if (alpha >= 1 && !isFadeIn) {
			Application.LoadLevel(fadeScene);
			DontDestroyOnLoad(gameObject);
		}
		if(alpha <= 0 && isFadeIn) {
			Destroy(gameObject);
		}
	}

	void OnLevelWasLoaded (int level) {
		isFadeIn = true;
	}
}
