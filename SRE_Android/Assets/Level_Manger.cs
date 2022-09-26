using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Level_Manger : MonoBehaviour {
	public Savings_data DataController;
	public Manger Man_sc;
	public static int current_level = 1;
	public PassEnd_message EndlevelText;


	public static int next_level;

	public static int noLastlevel = 9;


	public  int levels_completed;
	public  List <bool> Levels_Completed = new List<bool> {false,false, false, false, false, false, false,false,false};

	public Button Button_Level0;
	public Button Button_Level1;
	public Button Button_Level2;
	public Button Button_Level3;
	public Button Button_Level4;
	public Button Button_Level5;
	public Button Button_Level6;
	public Button Button_Level7;
	public Button Button_Level8;
	public Button Button_Level9;

	static public string HighScore_for_level; 
	string Stars_for_level;
	int stars_previously_awarded;
	int Stars_worth_of_orbs;
	List <Button> Level_Buttons = new List <Button>();

	void Start ()
	{
		
		 // to cheat the game

		HighScore_for_level = "HighScore:" + current_level.ToString ();
//		print (PlayerPrefs.GetInt (HighScore_for_level));


		//	for (int b = 0; (b-1) < levels_completed; b++)
		//	{
		//		PlayerPrefs.SetInt ("Highscore")

		if (Application.loadedLevel == 0) {
			for (int a = 0; a < levels_completed; a++) {
				Levels_Completed [a] = true;

			}
			Level_Buttons.Add (Button_Level1);
			Level_Buttons.Add (Button_Level2);
			Level_Buttons.Add (Button_Level3);
			Level_Buttons.Add (Button_Level4);
			Level_Buttons.Add (Button_Level5);
			Level_Buttons.Add (Button_Level6);
			Level_Buttons.Add (Button_Level7);
			Level_Buttons.Add (Button_Level8);
			Level_Buttons.Add (Button_Level9);

			int level_to_check = 0;

		
			foreach (Button buttons in Level_Buttons) {
				if (level_to_check == 0) {
					buttons.interactable = true;
				} else {
			
					buttons.interactable = Levels_Completed [level_to_check - 1];

				}
				level_to_check++;
			}
	
		}
	}

    

    public void ResetChallenge()
	{
		//Levels_Completed = new List<bool> {false,false, false, false, false, false, false, false, false };
		//levels_completed = 0;
		string stars_for_level;
		for (int a = 0; a < Levels_Completed.Count + 1; a++) {
			stars_for_level = "Stars_for_level:" + a.ToString ();
			HighScore_for_level = "HighScore:" + a.ToString();
			PlayerPrefs.SetInt (stars_for_level, 0);
			PlayerPrefs.SetInt (HighScore_for_level, 0);
		}
		int level_to_check = 0;



		foreach (Button buttons in Level_Buttons) {
			if (level_to_check == 0) {
				buttons.interactable = true;
			} else {

				buttons.interactable = Levels_Completed [level_to_check - 1];

			}
			level_to_check++;
		}
	}

	public void Completed_level()
	{
		if (current_level > levels_completed) 
		{
			levels_completed = current_level; // to set how many levels have been completed
					
		}
		if (levels_completed == noLastlevel) {
			print ("Donfdfdfdfddfdf");
			Man_sc.lastLevelCompleted = true;
		}

		HighScore_for_level = "HighScore:" + current_level.ToString(); // a highscore PlayerPref name for each level
		Stars_for_level = "Stars_for_level:" + current_level.ToString();// a stars record of PlayerPref name for each level
		print (PlayerPrefs.GetInt ("orb_Currency"));
		print ( Score.currentScore)	;
		int orbs_currency = PlayerPrefs.GetInt ("orb_Currency") + Score.currentScore; 

		PlayerPrefs.SetInt ("orb_Currency", orbs_currency); // add orb points onto the orb currency
		if (Score.currentScore > PlayerPrefs.GetInt(HighScore_for_level)) // check if the player has exceeded the previous highscore
		{
			Stars_worth_of_orbs = (int)(Mathf.Floor ((Score.currentScore-1) / 3)); //round up the score divided by 3 to be equivilant to stars
			stars_previously_awarded = PlayerPrefs.GetInt(Stars_for_level);// get the stars awarded for level last time
			PlayerPrefs.SetInt(HighScore_for_level, Score.currentScore ); //set the highscore to the score reached 
			PlayerPrefs.SetInt(Stars_for_level, Stars_worth_of_orbs ); // set the stars for the level 
			
			int Star_currency = PlayerPrefs.GetInt("Star_Currency"); // access the star currency

			print (PlayerPrefs.GetInt(Stars_for_level));
			print (stars_previously_awarded);
			print (PlayerPrefs.GetInt(Stars_for_level)-stars_previously_awarded);

//			Man_sc.starsCollected += PlayerPrefs.GetInt(Stars_for_level)-stars_previously_awarded;
			PlayerPrefs.SetInt("Star_Currency", (Star_currency+(PlayerPrefs.GetInt(Stars_for_level)-stars_previously_awarded))); // award stars for any extra earnt

		}
		DataController.SaveData ();
	}


	public void Level_select (int Level_number)
	{
		current_level = Level_number;



	}
	public void Next_Level()
	{

		current_level += 1;

	}	 

	public void RestartSCript()
	{
	//	PlayerPrefs.SetInt ("Levels_Completed_SAVED_INT", 8); // to cheat the game

		EndlevelText.Switch_Text ();

		HighScore_for_level = "HighScore:" + current_level.ToString ();

	//	int levels_completed = PlayerPrefs.GetInt ("Levels_Completed_SAVED_INT"); 
	}



}
