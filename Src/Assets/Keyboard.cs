using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour {

	public CardboardControl cardboard;

	// Use this for initialization
	void Start () {
		cardboard = GameObject.Find("CardboardControlManager").GetComponent<CardboardControl>();
		cardboard.trigger.OnUp += OnPress;  // When the trigger goes down
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnPress(object sender) {
		GameObject key = cardboard.gaze.Object ();
		Debug.Log ("Press on gaze: " + key.name);
		if (key != null) {
			if(key.tag == "Key") {
				string text = key.GetComponentInChildren<Text> ().text.Trim ();
				GameObject.FindGameObjectWithTag ("EmailInput").GetComponent<InputField> ().text += text;
			} else if(key.tag == "BackKey") {
				InputField field = GameObject.FindGameObjectWithTag ("EmailInput").GetComponent<InputField> ();
				field.text = field.text.Substring(0, field.text.Length-1);
			} else if(key.tag == "SendKey") {
				key.GetComponent<ScoreSender>().OnPress();
			}
		}
	}
}
