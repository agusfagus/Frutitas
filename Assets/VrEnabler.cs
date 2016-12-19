using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrEnabler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		bool vrEnabled = Scenes.getParam("vr") == "true";
		GvrViewer.Instance.VRModeEnabled = vrEnabled;
	}
}
