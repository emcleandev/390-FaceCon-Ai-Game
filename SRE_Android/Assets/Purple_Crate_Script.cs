using UnityEngine;
using System.Collections;

public class Purple_Crate_Script : MonoBehaviour {

	float PboxRadius = 1.3f;
	public Transform VictimCheck;
	public LayerMask WhatIsVictim;
	public static float FinalPJumpForce;
	public float PJumpForce = 1250f;
	bool Victim_presence = false;



	void Start () {
	
	}
	

	void FixedUpdate () {

		Victim_presence = Physics2D.OverlapCircle (VictimCheck.position, PboxRadius, WhatIsVictim);

		if (Victim_presence) {
			print ("working2");
			if (FinalPJumpForce != PJumpForce) {
				FinalPJumpForce = PJumpForce;
			}
		}
	}  
}
