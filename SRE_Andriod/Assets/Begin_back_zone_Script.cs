using UnityEngine;
using System.Collections;

public class Begin_back_zone_Script : MonoBehaviour {

	public int numpanels = 18;
	float width_of_boxs = 2.353356f;
	int a = 1;
	public Transform FirstBox;


	void Start () {
		GameObject[] Crate_set = GameObject.FindGameObjectsWithTag("Crate");
		
		foreach(GameObject Crate in Crate_set) 
		{
			a ++;
			Vector2 pos = FirstBox.position;
			pos.x += width_of_boxs * a;
			Crate.transform.position = pos;
		}

	
	}
	void OnTriggerEnter2D(Collider2D collider) {

		
		if(collider.tag == "Crate")
		{
		
			Vector2 pos = collider.transform.position;
			pos.x += width_of_boxs * numpanels;
			collider.transform.position = pos;

		}
		

	}
	// Update is called once per frame
	void Update () {
	
	}
}
