using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using System.Collections.Generic;

public class Product_Manger : MonoBehaviour {

	public Savings_data DataController;
	public int Cost_MysteryBox = 2;
	public int currentCostume;
	public Text collectionText;
	public SoundPlayer soundPlayer;
	public float chanceOfDuplicate;
	int chanceRange = 20;
	int randomVariable;
	public bool duplicate ;


	public List <bool> costumesBooleanList = new List<bool>{true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, 
		false, false, false, false, false, false, false, false, false, false, false,false, false, false, false}; // list of booean for comstumes owned or not owned
	List <int> IndexOfPurchasableCosutmes  = new List<int> {};  // a list where the index number of costumes not owned is to be randomised
	List <int> IndexOfOwnedCosutmes  = new List<int> {}; 



	//

	public Mystery_Crate MC_script;



	void Start () {
		
	//	PlayerPrefs.SetInt ("Star_Currency", 50);							// for testing
		CheckLists();


	}
	void CheckLists()
	{
		int range1 = costumesBooleanList.Count;
		IndexOfPurchasableCosutmes = new List<int> {};;
		for (int a = 0; a < range1; a++ )				//Creates a list of indexs of unpurhcased items
		{
			if (costumesBooleanList [a] == false) {
				IndexOfPurchasableCosutmes.Add (a);

			} else {
				if (a != 0) {
					IndexOfOwnedCosutmes.Add (a);

				}
			}

		}


	}
	

	void Update () { 
		if (Application.loadedLevel == 0) {
			int amountOwned = 0;
			for (int c = 0; c < costumesBooleanList.Count; c++) {				//Creates a list of indexs of unpurhcased items
				if (costumesBooleanList [c] == true)
					amountOwned++;
			}
			collectionText.text = amountOwned + " / " + costumesBooleanList.Count;
		}
	
	}

	public void Mystery_Crate_Purchase()
	{
		
		if ((PlayerPrefs.GetInt ("Star_Currency") >= Cost_MysteryBox) && (IndexOfPurchasableCosutmes.Count != 0)) {		// If the user has enough to purchase the mystery crate
			soundPlayer.Play_buttonSound();
			int Star_Currency = PlayerPrefs.GetInt ("Star_Currency");
			Star_Currency -= Cost_MysteryBox;								// deducts prize
			PlayerPrefs.SetInt ("Star_Currency", Star_Currency);

			Selection ();
			MC_script.BeginOpening ();										// Begins crate openning animation



		} else {
			soundPlayer.Play_DenySound ();
			
		}
	}
	void Selection()
	{
		CheckLists ();
		// randomizer to decide if costume is new

		float a = chanceOfDuplicate * chanceRange;
		int chance = Mathf.RoundToInt (a);
		int randomVariable = Random.Range (0, chanceRange);
		if ((randomVariable < chance )&&(IndexOfOwnedCosutmes.Count >0)) {
			print ("STAGE");
			duplicate = true;
			print ("STAGE2");
			int range2 = IndexOfOwnedCosutmes.Count;
			print ("STAGE3");
			int randomNumber = Random.Range (0, range2);
			print ("STAG4");

			int randomIndex = IndexOfOwnedCosutmes [randomNumber];
			print ("STAG5");
			currentCostume = PlayerPrefs.GetInt ("Character_Skin");
			PlayerPrefs.SetInt ("Character_Skin", randomIndex);						/// only prepares the change of the costume


		}
		else {
			duplicate = false;
			// random number bettwen length of lidex list
			int range2 = IndexOfPurchasableCosutmes.Count; 						
			int randomNumber = Random.Range (0, range2); 								// get the random index number
			/// the number matches the pref for the costume 
			int randomIndex = IndexOfPurchasableCosutmes [randomNumber]; 			/// store the index to be used to change the users costume

			IndexOfPurchasableCosutmes.RemoveAt (randomNumber); 						/// filter the list again for unowned items or just remove the item selected

			costumesBooleanList [randomIndex] = true;								/// in the orginal list set the correct index position to true 
			PlayerPrefs.SetInt ("Character_Skin", randomIndex);						/// only prepares the change of the costume
			currentCostume = randomIndex;


			DataController.SaveData ();
		}




	//	CheckLists ();		//// ADDEDED RECENTLY to check if this will prevent it form running if no purchasable items


		/// store the list using binary formatting

}
}