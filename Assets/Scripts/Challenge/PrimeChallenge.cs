using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PrimeChallenge : Challenge {

	private static int[] PRIME_NUMBERS = {
		2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97
	};

	public PrimeChallenge() {
	}

	#region Challenge implementation

	public string message ()
	{
		return "Shoot the balloons with Prime Numbers";
	}

	public string shortMessage ()
	{
		return "Shoot the primes";
	}

	public bool verify (int number)
	{
		int pos = Array.IndexOf(PRIME_NUMBERS, number);
		return pos > -1;
	}

	#endregion


}
