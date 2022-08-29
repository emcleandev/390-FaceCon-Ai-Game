using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void SetingsPanel (GameObject panel) 
	{
		panel.SetActive (!panel.activeSelf);
	}
}
