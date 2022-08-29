using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PassEnd_message : MonoBehaviour {

	Text message_text; 
	string level_text_attach;
	bool Switched_Text = false;

	void Awake () {
		message_text = GetComponent<Text>();
	
	}
	void Start()
	{
		Switch_Text ();
	}
	void update()
	{
		if (!Switched_Text)
		{
			
			//Switch_Text ();
	}
	}

	public void Switch_Text () 
	{
		Switched_Text = true;	
		level_text_attach = Level_Manger.current_level.ToString();

		message_text.text = "WELL DONE ! \n level " +level_text_attach +" passed";
	
	}
}
