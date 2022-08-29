using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bottom_leap_button : MonoBehaviour {

	Button button;
	Image image;

	void Awake() 
	{

		button = GetComponent <Button>();
		image = GetComponent <Image> ();

	}
	

	void Update () 
	{
		if (Victim_Movement.Bottomset) {
			//button.interactable = false;
			//image.enabled = false;
		} else {
			if (Victim_Movement.Cbelow) {
				//button.interactable = false;
				//image.enabled = false;
			} else {	
				button.interactable = true;
				image.enabled = true;
			}
		}

	}
} 