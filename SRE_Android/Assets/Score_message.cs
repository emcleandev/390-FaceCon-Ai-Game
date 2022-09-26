using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score_message : MonoBehaviour {

	string Highscore_for_level;
	int Score_for_message;
	Text text;
	string message;
	void Start () {
        print("current level is :" + Level_Manger.current_level.ToString());

		text = GetComponent <Text> ();
		Highscore_for_level = "HighScore:" + Level_Manger.current_level.ToString();
	}
	

	void Update () {
		Highscore_for_level = "HighScore:" + Level_Manger.current_level.ToString(); 
		Score_for_message = Score.currentScore;
        print("current level is :" + Level_Manger.current_level.ToString());
        message = "Highscore is " + PlayerPrefs.GetInt(Highscore_for_level)+ "\n you got " + Score_for_message;
		text.text = message; 

	
	}
}
