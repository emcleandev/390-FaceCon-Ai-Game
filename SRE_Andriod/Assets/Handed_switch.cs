using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Handed_switch : MonoBehaviour {
	bool RightHanded = true;
	Text text;
	// Use this for initialization

	void Awake () 
	{
		text = GetComponent <Text>();
	
	}
	
	// Update is called once per frame
	public void Switch_handed () 
	{

		if (RightHanded)
		{
			RightHanded = false;
			text.text = "Left Handed";
		}
		else if (!RightHanded)
		{
			RightHanded = true;
			text.text = "Right Handed";
		}


		 
	
	}
}
