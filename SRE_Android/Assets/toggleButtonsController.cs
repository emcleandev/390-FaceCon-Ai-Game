using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class toggleButtonsController : MonoBehaviour {
	public Savings_data DataController;
	public Toggle leapButtonsTog;
	public Manger Man_sc;

	void Start(){
		print (Man_sc.leapButtonsOn);
		leapButtonsTog.isOn = Man_sc.leapButtonsOn;

	}

	public void Change()
	{
		Man_sc.leapButtonsOn = leapButtonsTog.isOn;
		DataController.SaveData ();
		print ("ran" + Man_sc.leapButtonsOn);
	}



}
