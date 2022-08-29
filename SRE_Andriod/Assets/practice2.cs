using UnityEngine;
using System.Collections;

public class practice2 : MonoBehaviour 

	{
		void Start()
		{
			//You can access a static variable by using the class name
			//and the dot operator.
			int x = pratice1.playerCount;
			print (x);
			print (pratice1.playerCount);
			pratice1.playerCount = 3;
		print (pratice1.playerCount);
		}
	}
