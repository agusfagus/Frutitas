using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	private static SoundManager instance;

	public static SoundManager Instance() {
		return instance;
	}

	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		instance = this;
		audioSource = GetComponent<AudioSource> ();
	}

	public void play (AudioClip clip) {
		audioSource.PlayOneShot (clip);
	}
}
