using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Challenge {
	bool verify (int number);
	string message();
	string shortMessage();
}
