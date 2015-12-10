using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackspaceKey : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnPress() {
		InputField field = GameObject.FindGameObjectWithTag ("EmailInput").GetComponent<InputField> ();
		field.text = field.text.Substring(0, field.text.Length-1);
	}
}
