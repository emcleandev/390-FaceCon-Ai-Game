using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void StartButton (GameObject button) 
	{
		button.SetActive (!button.activeSelf);
	}
	public void CharactersButton (GameObject button2) 
	{
		button2.SetActive (!button2.activeSelf);
	}
	public void MoreButton (GameObject  button3) 
	{
		button3.SetActive (!button3.activeSelf);
	}
	public void Title (GameObject  Title) 
	{
		Title.SetActive (!Title.activeSelf);
	}
	public void HighScore (GameObject  HighScore) 
	{
		HighScore.SetActive (!HighScore.activeSelf);
	}


}
