using UnityEngine;
using System.Collections;

public class End_level_trigger : MonoBehaviour {

	GameObject Manger;
	GameObject Level_Manger;
	public static bool ended ;
	bool triggered_once;
	Component Manger_script;
	void Start () {
		ended = false;


	}
	
	// Update is called once per frame
	void Awake () {
		ended = false;
		Manger = GameObject.Find ("Manger play");
		Level_Manger = GameObject.Find ("Level Manger");

		triggered_once = false;
	}
	void OnTriggerEnter2D(Collider2D collider) 
	{
		Debug.Log ("Triggered: " + collider.name);
		
		if((collider.tag == "Player")&& (triggered_once == false))
		{
			triggered_once = true;
			ended = true;

			Manger.GetComponent<Manger>().End_Level(true);
			Level_Manger.GetComponent<Level_Manger>().Completed_level ();
		}
	}

}