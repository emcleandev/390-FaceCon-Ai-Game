using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class star_currecny_script : MonoBehaviour {

	Text text;
//	string Message;
	int Star_currency_for_message;
	public Animation Amation;


	void Start () {
		text = GetComponent <Text> ();
		Star_currency_for_message  = (PlayerPrefs.GetInt("Star_Currency")) ;
		text.text = Star_currency_for_message.ToString();

	}
	
	void Awake () {

		
	}
	void Update () {
		if (Star_currency_for_message != PlayerPrefs.GetInt ("Star_Currency")) 
		{
			Amation.Play ("StarAnimation");
			Star_currency_for_message = (PlayerPrefs.GetInt ("Star_Currency"));
			text.text = Star_currency_for_message.ToString ();
		}
	}
}
