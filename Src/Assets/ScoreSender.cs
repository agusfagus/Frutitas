using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class ScoreSender : MonoBehaviour {

	public string restartScene;
	public string scorePostUrl;
	private Button button;

	// Use this for initialization
	void Start () {
		button = GetComponent<Button> ();
		button.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnEmailChange() {
		string email = GameObject.FindGameObjectWithTag("EmailInput").GetComponent<InputField>().text;
		Debug.Log (email + TestEmail.IsEmail (email));
//		if (TestEmail.IsEmail (email)) {
		if (email.Length > 0) {
			button.interactable = true;
		} else {
			button.interactable = false;
		}
	}

	public void OnPress() {
		StartCoroutine ("SendScore");
	}

	private IEnumerator SendScore() {
		if (!button.IsInteractable())
			yield break;
		WWWForm form = new WWWForm();
		System.Collections.Generic.Dictionary<string,string> headers = form.headers;
		Hashtable rawData = new Hashtable();
		rawData ["name"] = GameObject.FindGameObjectWithTag("EmailInput").GetComponent<InputField>().text;
		rawData ["score"] = Player.score;
		rawData ["device"] = SystemInfo.deviceModel;
		rawData ["duration"] = Time.timeSinceLevelLoad.ToString ();
		string json = "{\"score\":\""+rawData["score"]+"\","+
			" \"duration\":\""+rawData["duration"]+"\","+
				" \"name\":\""+rawData["name"]+"\","+
				" \"device\":\""+rawData["device"]+"\" }";
		byte[] bytes = Encoding.UTF8.GetBytes(json);
		
		headers["Content-Type"] = "application/json";
		headers["X-Parse-Application-Id"] = "AgbCv2IdOihHPcIuvH3PItFACXiwNG0pDfVuuvnD";
		headers["X-Parse-REST-API-Key"] = "9YPTNj3LuPArgOUImPhUQKi5jqkhSfLKb3IvMnfd";
		headers["X-Parse-Master-Key"] = "ycsMy49UqD1T5IbmhffM1uuNuKXBcfIL2g314I0q";
		
		WWW postRequest = new WWW( scorePostUrl, bytes, headers );
		yield return postRequest;
		if (!string.IsNullOrEmpty(postRequest.error)) {
			Debug.Log(postRequest.error);
		}
		else {
			Debug.Log("Finished Uploading Scores");
			Initiate.Fade(restartScene, null, 0.95f);
		}
	}
}
