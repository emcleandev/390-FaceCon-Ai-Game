using UnityEngine;
using System.Collections.Generic;

public class BOXs : MonoBehaviour {

	public List<SpriteRenderer> CratespriteList = new List<SpriteRenderer>();

	public GameObject Manger;
	//public GameObject[] Test; shows how to create a list of a variable type
	public bool allowBoxesToInvisible;


	void Start () {
		


	
	}
	
	// Update is called once per frame
	void Update () {

		if (allowBoxesToInvisible == true) {
			foreach (SpriteRenderer cratesprite in CratespriteList) {
		
				cratesprite.enabled = !Manger.GetComponent<Manger> ().clearCrates;
			
			}
		}
	}
}
