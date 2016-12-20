using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenChallenge : Challenge {
	#region Challenge implementation

	public string message ()
	{
		return "Shoot the balloons with multiples of seven";
	}

	public string shortMessage ()
	{
		return "Shoot multiples of 7";
	}

	public bool verify (int number)
	{
		return (number % 7) == 0;
	}

	#endregion
}
