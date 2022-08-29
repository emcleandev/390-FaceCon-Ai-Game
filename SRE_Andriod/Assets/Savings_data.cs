using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class Savings_data : MonoBehaviour {


	public Manger Man_sc;
	public Daily_controller Daily_sc;
	public Level_Manger LevelMans_sc;
	public Product_Manger ProductMans_sc;

	void Start () {
		//SaveData ();
	
	}


		

	public  void SaveData()
	{
		
		PlayerPrefs.Save ();
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/GameData.gd");
		GameData data = new GameData ();

		data.lastLevelCompleted = Man_sc.lastLevelCompleted;
		data.levels_completed = LevelMans_sc.levels_completed;
		//data.Stars_amount = 50;    //         Self Comment: Stars are still stored using player pref so no need
//		data.DeathCount =  Man_sc.DeathCount;
	//	data.Stars_collected = Man_sc.starsCollected;
		data.LastTime_resetCheck = Daily_sc.lastReset.ToString ();

		data.leapButtonToggleOn = Man_sc.leapButtonsOn;
		data.costumesBooleanList = ProductMans_sc.costumesBooleanList;


		bf.Serialize (file, data);
		file.Close ();
	}
	public  void loadData()
	{
		if (File.Exists (Application.persistentDataPath +"/GameData.gd"))
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/GameData.gd", FileMode.Open);
			GameData data = (GameData)bf.Deserialize (file);
			file.Close();
			Man_sc.lastLevelCompleted = data.lastLevelCompleted;
			LevelMans_sc.levels_completed = data.levels_completed;
	//		Man_sc.starsCollected = data.Stars_collected;
	//		Man_sc.DeathCount = data.DeathCount;
			Man_sc.leapButtonsOn = data.leapButtonToggleOn;
			Daily_sc.lastReset = Convert.ToDateTime(data.LastTime_resetCheck);

			ProductMans_sc.costumesBooleanList = data.costumesBooleanList;


		}
				
}
}

[Serializable]

class GameData{
		
	public int levels_completed;
	public bool lastLevelCompleted; // at some point has the user completed the last level
//	public int Stars_amount;
//	public int Stars_collected;
	public string LastTime_resetCheck;
	public List <bool> costumesBooleanList = new List<bool>{true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, 
		false, false, false, false, false, false, false, false, false, false, false,false, false, false, false};
//	public int DeathCount;
	public bool leapButtonToggleOn;
	}
