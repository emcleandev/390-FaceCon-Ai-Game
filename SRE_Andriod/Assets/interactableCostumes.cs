using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class interactableCostumes : MonoBehaviour {

	public Button[] bttns;
	public Product_Manger pManager;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for(int a = 0;  a < bttns.Length; a++)
		{
			bttns[a].interactable = pManager.costumesBooleanList[a]; 
		}
	}
}
