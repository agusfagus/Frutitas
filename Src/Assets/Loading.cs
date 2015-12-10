using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {
	private bool loading = true;
	
	public Texture loadingTexture;

	void Start () {
		Debug.Log ("Don't destroy");
		DontDestroyOnLoad(gameObject);
	}
	
	void Update () {
		if(Application.isLoadingLevel)
			loading = true;
		else
			loading = false;
	}
	
	void OnGUI () {
		if (loading) {
			Debug.Log ("Loading");
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), loadingTexture, ScaleMode.StretchToFill);
		}
	}
}