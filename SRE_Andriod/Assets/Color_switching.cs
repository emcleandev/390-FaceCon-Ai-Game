using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Color_switching : MonoBehaviour {
	public Color[] color;
	Image image;
	int count = 0;
	bool Switched = true;
	void Start () 
	{
		image = GetComponent<Image> ();

	
	}
	

	void Update () 
	{
		
		if (image.color == color [count+1])
		{
			print ("bye");
			count++;
			Switched = true;
		}
		if (count == (color.Length-1))
		{
			count = 0;
		}	

		if (Switched == true)
		{
			Fade_Colors();
			Switched= false;
			print ("helllo");
		}	


	}

	void Fade_Colors()
	{
		image.color = Color.Lerp (color [count+1], color [count],Mathf.PingPong(Time.time, 1));
	}
	
		 




}
