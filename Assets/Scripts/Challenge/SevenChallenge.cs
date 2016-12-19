using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenChallenge : Challenge {
	#region Challenge implementation

	public bool verify (int number)
	{
		return (number % 7) == 0;
	}

	#endregion
}
