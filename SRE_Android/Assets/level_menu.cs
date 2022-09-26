using UnityEngine;
using System.Collections;

public class level_menu : MonoBehaviour {

	public GameObject  panel2;

	// Use this for initialization
	void Start () {
	
	}
	
	public void Level_menu_Panel (GameObject  panel) 
	{
		panel.SetActive (!panel.activeSelf);
		panel2.SetActive (!panel2.activeSelf);
}
}
