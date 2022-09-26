using UnityEngine;
using System.Collections;

public class Screen_Ui_con3 : MonoBehaviour {


	string currentScreenRotation;
	void Start () { 
		if (Application.loadedLevel == 0)
			changeScreenToPortrait ();
		else
			changeScreenToAutoRotate();

	}



	void Update () {




	}
	void changeScreenToPortrait()
	{
		Screen.orientation = ScreenOrientation.Portrait;
	}
	void changeScreenToAutoRotate()
	{

		Screen.orientation = ScreenOrientation.AutoRotation;
	}
}