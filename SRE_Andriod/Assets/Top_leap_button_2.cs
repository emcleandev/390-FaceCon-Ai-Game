using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Top_leap_button_2 : MonoBehaviour {

	// Use this for initialization
	Button button;
	Image image;
	
	void Awake() 
	{
		
		button = GetComponent <Button>();
		image = GetComponent <Image> ();
	}
	
	
	void Update () 
	{
		if ((Victim_Movement.Topset)||(Victim_Movement.TopC2set)) {
			//image.enabled = false;
			//button.interactable = false;
		} else {
			if (Victim_Movement.Cabove) {
			//	button.interactable = false;
			//	image.enabled = false;
			} else {
				button.interactable = true;
				image.enabled = true;
			}
		
		}
	}
} 