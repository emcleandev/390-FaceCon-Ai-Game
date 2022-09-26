using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Change_colour : MonoBehaviour {

	public Image Mute_image;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Manger.OnMute) 
		{
			Mute_image.color = Color.red;
		}
		else
		{
			Mute_image.color = Color.white;
		}
		
	}
	
	}

