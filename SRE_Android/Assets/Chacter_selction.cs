using UnityEngine;
using System.Collections;

public class Chacter_selction : MonoBehaviour {




	void Start () {
	
	}
	

	void Update () {
	
	}
	public void Skin_Change (int nOSkin) 
	{
		PlayerPrefs.SetInt ("Character_Skin", nOSkin);
	}
}
