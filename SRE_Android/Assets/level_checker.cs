using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class level_checker : MonoBehaviour {

	string current_level;
	public Text Level_text;
	public bool leveled_up= true;
	public GameObject Level;
//	float orginalcountdown = 100f;
	float begincountdown;
//	Text text;
	Animator anim;
	bool countingdown;

	 
	void Start ()
	{
		//anim = Level.GetComponent<Animator> ();
//		text = GetComponent<Text>();


		
	
	}
	void update ()
	{


		
		
	}
	
	void OnTriggerEnter2D(Collider2D collider) 
	{


		if (collider.tag == "Level") 
		{
			print ("leveled up");
			current_level = collider.name;
			Level_text.text = ""+ current_level;






			

		}
		}
	}

