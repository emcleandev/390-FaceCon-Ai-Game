using UnityEngine;
using System.Collections;

public class Collision_Check : MonoBehaviour {


	void Start () {
	
	}
	

	void OnTriggerEnter2D(Collider2D collider) 
	{
		Debug.Log ("Triggered: " + collider.name);
		if((collider.tag == "Obstacles")||(collider.tag == "Box_Sets"))
		{
			//Victim_Movement.dead = true;
		}

	}
}
