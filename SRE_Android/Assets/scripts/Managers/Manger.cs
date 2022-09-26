using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Manger : MonoBehaviour {
	public Savings_data SavingsData;
	public Daily_controller Daily_con;
	public Level_Manger Level_Mans;
	public static bool OnMute = false;
	public Back_zone_scipt Backzone; // calling just the script(experiment)
	public Camera_follow MainCamera_camera_follow_script;
	Victim_Movement VictimMoveScript;

//	bool Pause = false;
//	bool Play = true;
//	static float restarted = 0f;
	static bool music; 
	float Pressed = 3f; 
//	static bool began = false;
	float FadeTime;
	public static bool Level_Ended = false;
	public bool Level_EndedCamera = false;
	public string Game_scene;
	public string Main_menu_scene;
	public static bool Level_menu_condition = false;
	public Level_Text_Fade_control lvlFadeControl;
	public GameObject Fade;
	public GameObject Victim;

	public GameObject Result_panel;

	public GameObject Main_Menu;
	public GameObject level_menu ;
	public GameObject Character_menu;
	public GameObject Prize_menu;
	public GameObject Help_panel;

	public GameObject Play_mode_panal;
	public GameObject Play_mode_panal2;
	public GameObject End_mode_panalPass;
	public GameObject End_mode_panalFail;

//	int orb_currency = 0;
//	int new_orb_currency = 0;
	Animator anim;
	SpriteRenderer vspri;
 	
	public bool Main_open = true;
	public bool level_open = false;
	 
	public bool lastLevelCompleted;
	public bool clearCrates;

	public bool leapButtonsOn;


	public GameObject LeapButtonPanel;

	public Text title;



	void Awake(){
	//	SavingsData.SaveData ();
		SavingsData.loadData ();
	//	PlayerPrefs.SetInt ("Star_Currency", 50);

	}



	void Start()
	{
//		print (DeathCount);
//		print (starsCollected);
//		print (PlayerPrefs.GetInt ("orb_Currency"));
//		print (PlayerPrefs.GetInt ("Star_Currency"));
//		print (Score.highscore);
//		print (Score.currentScore);

		anim = Victim.GetComponent <Animator> (); 
		vspri = Victim.GetComponent <SpriteRenderer> ();
		VictimMoveScript= Victim.GetComponent<Victim_Movement> ();

        if (Application.loadedLevel == 0)
        {
            Level_Ended = true;
        }else if (Application.loadedLevel == 1){
            Level_Ended = false;
        }
        if (Application.loadedLevel == 0 && lastLevelCompleted == true)
        {
            title.text = "SOAP\nKInG";
        }

		if (Level_menu_condition) 
		{
			Level_selection_open (true);
			Level_menu_condition = false;
			Load_Game_Scene_pt2();
		}

		LeapButtonsActiveCheck ();
		 


	}
	public void Mute()
	{
		OnMute = !OnMute;
	}
	public void resetChallenge()
	{
		
		int levels_completed = Level_Mans.levels_completed;
		print (levels_completed);
		print ("Reseting challenge");
		print ("show results");
		Level_Mans.ResetChallenge ();

		SavingsData.SaveData ();
		/*
		if (levels_completed > 1) {
			

			Result_panel.SetActive (true);
			Result_panel.GetComponent<Results_controller> ().UpdateInfo ();
			Main_Menu.SetActive (false);
			level_menu.SetActive (false);
			Prize_menu.SetActive (false);
			Character_menu.SetActive (false);
			Help_panel.SetActive (false);

			anim.enabled = false; 
			vspri.enabled = false;
		}
		Level_Mans.ResetChallenge ();
		DeathCount = 0;
		starsCollected = 0;
		SavingsData.SaveData ();
*/

	}

		


	public void End_Level(bool Pass)
	{
		
		Play_mode_panal.SetActive (false);
		Play_mode_panal2.SetActive (false);
		//	orb_currency = PlayerPrefs.GetInt("orb_Currency");
		//new_orb_currency = orb_currency + Score.score;

//		PlayerPrefs.SetInt ("orb_Currency", new_orb_currency);


		if ((Pass) && (!Level_Ended)) {
			End_mode_panalPass.SetActive (true);
			End_mode_panalFail.SetActive (false);
			Level_Ended = true;
			Level_EndedCamera = true;

		} else {
			if (!Level_Ended) {
//				DeathCount += 1;
				Daily_con.checkForReset();

				End_mode_panalFail.SetActive (true);
				End_mode_panalPass.SetActive (false);

				anim.enabled = false;
				vspri.enabled = false;
				End_LevelPt2 ();
				Level_Ended = true;	
				Level_EndedCamera = true;	

				//	v_movement.No_velocity_by_Death = false;
//			Victim_C_Movement.No_veleoctiy_by_Death = true;
			}
			// MAybe a function that is called to save data. Example SaveData(). to save data like highscore, levels passed etc.
		}
		SavingsData.SaveData ();
	}
	void End_LevelPt2 ()
	{
		
		VictimMoveScript.No_veleoctiy_by_Death = true;
	}


	public  void Prize_Menu_button(bool Prize_menu_open)
	{
		Flash_fade (Color.white);
		Main_open = !Prize_menu_open;

		Main_Menu.SetActive (Main_open);
		Prize_menu.SetActive (Prize_menu_open);
		anim.enabled = Main_open; 
		vspri.enabled = Main_open;






	}
	public  void Help_Panel_button(bool Help_panel_open)
	{
		Main_open = !Help_panel_open;
		Main_Menu.SetActive (Main_open);
		Help_panel.SetActive (Help_panel_open);
		anim.enabled = Main_open; 
		vspri.enabled = Main_open;
		clearCrates = Help_panel_open;


	}

	public void Character_selection_open(bool character_open)
	{
		Main_open = !character_open;

		Main_Menu.SetActive (Main_open);
		Character_menu.SetActive (character_open);
	//	anim.enabled = Main_open; 
	//	vspri.enabled = Main_open;

	//	clearCrates = character_open;

	}

	public void Main_Menu_button() // i belive they are in game buttons
	{
		print ("Opening Main menu");
		StartCoroutine(Load_Main_menu());
		
	}

	public void Level_Menu_button()
	{
//		print ("Opening Level selects");

		Level_menu_condition = true;
		StartCoroutine(Load_Main_menu());


	}

	public void Level_selection_open (bool Level_open)
	{
		clearCrates = Level_open;

		Main_open  = !Level_open;

		level_open = Level_open;






		Main_Menu.SetActive (Main_open);
		level_menu.SetActive (Level_open);
		anim.enabled = Main_open; 
		vspri.enabled = Main_open;


	}

	public void Flash_fade (Color color__)
	{
//		Fade.GetComponent<scene_Fade_Script>().TrickFade(); 
		Fade.GetComponent<scene_Fade_Script>().BeginFade(-1, color__); 
	}



	IEnumerator Load_Main_menu()
	{
		
		float FadeTime = (1/(Fade.GetComponent<scene_Fade_Script>().BeginFade(1, Color.black))); 
		yield return new WaitForSeconds (FadeTime);
		Application.LoadLevel (0);
	}

	IEnumerator Load_Game_Scene_pt2()
	{


		float FadeTime = (1/(Fade.GetComponent<scene_Fade_Script>().BeginFade(1, Color.black))); 
		yield return new WaitForSeconds (FadeTime);
		Application.LoadLevel (1);

	}

	private void LeapButtonsActiveCheck()
	{

		if (Application.loadedLevel == 1) {
			print ("working");
			print (leapButtonsOn);
			if (Level_Manger.current_level == 1) {
				LeapButtonPanel.SetActive (false);
			} else {
				
				LeapButtonPanel.SetActive (leapButtonsOn);
			}
		}
	}



	public void RestartToSpawnPoint()
	{
		Flash_fade (Color.black);
		LeapButtonsActiveCheck ();
		Score.currentScore = 0;
		Backzone.RestartPositions ();



		MainCamera_camera_follow_script.Restart_camera_position ();
		End_mode_panalFail.SetActive (false);
		End_mode_panalPass.SetActive (false);

		anim.enabled = true;
		vspri.enabled = true;

		Level_Ended = false;	
		Level_EndedCamera = false;	


		VictimMoveScript.No_veleoctiy_by_Death = false;
		VictimMoveScript.dead = false;
		VictimMoveScript.Restart_Countdown_for_gamerestart();
        VictimMoveScript.runForward();

		Play_mode_panal.SetActive (true);
		Play_mode_panal2.SetActive (true);

		lvlFadeControl.begin_state ();
	}

	public void ResultsTapLeave()
	{
		Main_Menu.SetActive (true);
		Result_panel.SetActive(false);
		anim.enabled = true; 
		vspri.enabled = true;
	}




	public void Load_Game_Scene_pt1()
	{

		StartCoroutine(Load_Game_Scene_pt2());

	}	


	public void run_Pause( )
	{
		print ("PAUSE");
		Pressed += 1;
		if ((Pressed % 2 == 0) || (Pressed == 1))
		{
			Time.timeScale = 0.0f;

		} 
		else 
		{
			Time.timeScale = 1.0f;
		}
	}
//	public void Main_Menu_Play (string Play_script)
//	{
//		Application.LoadLevel (Play_script);
//		print ("Loading game...");
//	}
}
