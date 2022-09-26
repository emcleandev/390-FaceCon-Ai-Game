using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class Star_panal_script : MonoBehaviour {
	public int level;
	public Toggle Star1;
	public Toggle Star2;
	public Toggle Star3;
	public Toggle Star4;
	public Toggle Star5;
	public Toggle Star6;
	public Toggle Star7;
	public Toggle Star8;
	public Toggle Star9;

	string stars_for_level;
	public bool End_stage_level = false;
	int Stars_;

	void Update() {
		stars_for_level = "Stars_for_level:" + level.ToString();
		Stars_ = PlayerPrefs.GetInt (stars_for_level);
		if (End_stage_level) {
			if (Stars_ == 10) {
				Star1.isOn = true;
				Star2.isOn = true;
				Star3.isOn = true;
				Star4.isOn = true;
				Star5.isOn = true;
				Star6.isOn = true;
				Star7.isOn = true;
				Star8.isOn = true;
				Star9.isOn = true;

				
			}
			if (Stars_ == 9) {
				Star1.isOn = true;
				Star2.isOn = true;
				Star3.isOn = true;
				Star4.isOn = true;
				Star5.isOn = true;
				Star6.isOn = true;
				Star7.isOn = true;
				Star8.isOn = true;
				Star9.isOn = false;

				
				
			}
			if (Stars_ == 8) {
				Star1.isOn = true;
				Star2.isOn = true;
				Star3.isOn = true;
				Star4.isOn = true;
				Star5.isOn = true;
				Star6.isOn = true;
				Star7.isOn = true;
				Star8.isOn = false;
				Star9.isOn = false;

				
				
			}
			if (Stars_ == 7) {
				Star1.isOn = true;
				Star2.isOn = true;
				Star3.isOn = true;
				Star4.isOn = true;
				Star5.isOn = true;
				Star6.isOn = true;
				Star7.isOn = false;
				Star8.isOn = false;
				Star9.isOn = false;



			}
			if (Stars_ == 6) {
				Star1.isOn = true;
				Star2.isOn = true;
				Star3.isOn = true;
				Star4.isOn = true;
				Star5.isOn = true;
				Star6.isOn = false;
				Star7.isOn = false;
				Star8.isOn = false;
				Star9.isOn = false;



			}
			if (Stars_ == 5) {
				Star1.isOn = true;
				Star2.isOn = true;
				Star3.isOn = true;
				Star4.isOn = true;
				Star5.isOn = false;
				Star6.isOn = false;
				Star7.isOn = false;
				Star8.isOn = false;
				Star9.isOn = false;



			}
			if (Stars_ == 4) {
				Star1.isOn = true;
				Star2.isOn = true;
				Star3.isOn = true;
				Star4.isOn = false;
				Star5.isOn = false;
				Star6.isOn = false;
				Star7.isOn = false;
				Star8.isOn = false;
				Star9.isOn = false;



			}

			if (Stars_ == 3) {
				Star1.isOn = true;
				Star2.isOn = true;
				Star3.isOn = false;
				Star4.isOn = false;
				Star5.isOn = false;
				Star6.isOn = false;
				Star7.isOn = false;
				Star8.isOn = false;
				Star9.isOn = false;



			}
			if (Stars_ == 2) {
				Star1.isOn = true;
				Star2.isOn = false;
				Star3.isOn = false;
				Star4.isOn = false;
				Star5.isOn = false;
				Star6.isOn = false;
				Star7.isOn = false;
				Star8.isOn = false;
				Star9.isOn = false;



			} else {
				Star1.isOn = false;
				Star2.isOn = false;
				Star3.isOn = false;
				Star4.isOn = false;
				Star5.isOn = false;
				Star6.isOn = false;
				Star7.isOn = false;
				Star8.isOn = false;
				Star9.isOn = false;
			}

		} else {
			if (Stars_ >= 3) {
				Star1.isOn = true;
				Star2.isOn = true;
				Star3.isOn = true;
				
				
			}
			if (Stars_ == 2) {
				Star1.isOn = true;
				Star2.isOn = true;
				Star3.isOn = false;
				
				
			}
			if (Stars_ == 1) {
				Star1.isOn = true;
				Star2.isOn = false;
				Star3.isOn = false;
				
				
			}
			if (Stars_ == 0) {
				Star1.isOn = false;
				Star2.isOn = false;
				Star3.isOn = false;
				
				
			}
		}

		
	}

	


}
