using UnityEngine.UI;
using UnityEngine;

using System.Collections;

public class orb_currency_script : MonoBehaviour {

	int Orb_currency_for_message  ;
	Text text;
	string Message;
	void Start () {
		text = GetComponent <Text> ();
		Orb_currency_for_message  = (PlayerPrefs.GetInt("orb_Currency")) ;
		text.text = Orb_currency_for_message .ToString();

		
	}
	void Awake () {

		
	}
	
//	void Update () {
//		Orb_currency_for_message  = (PlayerPrefs.GetInt("orb_Currency")) ;
//		text.text = Orb_currency_for_message .ToString();
		
//	}
}

