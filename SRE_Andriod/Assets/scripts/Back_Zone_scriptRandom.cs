using UnityEngine;
using System.Collections.Generic;

public class Back_Zone_scriptRandom : MonoBehaviour {

	int Random;
	int Last_Random;
	
	int numpanels = 3;
	float width_of_boxs = 201.4f;
	
	List<Transform> PrefabBoxsetList = new List<Transform>();
	
	public Transform First_Set;
	public Transform Second_Set;
	public Transform Third_Set;
	
	public Transform Box_Set1;
	public Transform Box_Set2;
	public Transform Box_Set3;
	public Transform Box_Set4;
	public Transform Box_Set5;
	public Transform Box_Set6;
	public Transform Box_Set7;
	public Transform Box_Set8;
	public Transform Box_Set9;
	public Transform Box_Set10;
	public Transform Box_Set11;
	public Transform Box_Set12;
	
	
	void Start () 
	{
		Random = UnityEngine.Random.Range(1,4);
		Last_Random= Random;
		
		PrefabBoxsetList.Add(Box_Set1);
		PrefabBoxsetList.Add(Box_Set2);
		PrefabBoxsetList.Add(Box_Set3);
		PrefabBoxsetList.Add(Box_Set4);
		
		
		
		
		Instantiate(PrefabBoxsetList[0],First_Set.transform.position, Quaternion.identity);
		
		Instantiate(PrefabBoxsetList[Random],Second_Set.transform.position, Quaternion.identity);
		
		
		Random = UnityEngine.Random.Range(1,4);
		
		while (Random == Last_Random) 
		{
			Random = UnityEngine.Random.Range (1,4);
		}
		Last_Random = Random;
		
		Instantiate(PrefabBoxsetList[Random],Third_Set.transform.position, Quaternion.identity);
		
		GameObject[] Box_Set = GameObject.FindGameObjectsWithTag("Box_Sets");
		
		
		foreach(GameObject Box_Sets in Box_Set) 
		{
			Vector2 pos = Box_Sets.transform.position;
			Box_Sets.transform.position = pos;
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log ("Triggered: " + collider.name);
		
		if(collider.tag == "SET")
		{
			Random = UnityEngine.Random.Range(1,4);
			
			while (Random == Last_Random) 
			{
				Random = UnityEngine.Random.Range (1,4);
				
			}
			Last_Random= Random;
			
			Vector2 pos = collider.transform.position;
			pos.x += width_of_boxs * numpanels;
			
			collider.transform.position = pos;
			Instantiate(PrefabBoxsetList[Random],collider.transform.position, Quaternion.identity);
		}
		
		if (collider.tag == "Box_Sets") 
		{
			Destroy (collider.gameObject);
			
		}
		
	}
	void Update () {
		
		
	}
}
