using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class interactable_conditions : MonoBehaviour {

	public Text button_label;
	Button button;

	void Start () {
		button = GetComponent <Button>();
		if (button.interactable == true) {
			button_label.color = Color.white;
		} else
			button_label.color = new Color(0.184f,0.184f,0.184f,1);
	}

	
	// Update is called once per frame
	void Update () {
		
		if (button.interactable == true) {
			button_label.color = Color.white;
		} else
			button_label.color = new Color(0.184f,0.184f,0.184f,1);
	}
//		if (button.interactable == true) {
//			button_label.color = Color.white;
//		} else
//			button_label.color = new Color(0.184f,0.184f,0.184f,1);
	}


