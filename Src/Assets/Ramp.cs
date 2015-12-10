using UnityEngine;
using System.Collections;

public class Ramp {
	
	public static float Interpolate(float from, float to, float rampScore) {
		if (Player.score >= rampScore) {
			return to;
		} else {
			float range = to - from; //This is negative if decreasing
			return from + range * Player.score / rampScore;
		}
	}

}
