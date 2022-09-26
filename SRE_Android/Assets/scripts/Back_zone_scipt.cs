using UnityEngine;
using System.Collections.Generic;

public class Back_zone_scipt : MonoBehaviour {

	int Random;
	int Last_Random;
	int next;
	bool Finished_Main_Cycle = false;

	int numpanels = 3;
	float width_of_boxs = 201.4f;

	List<Transform> PrefabBoxsetList = new List<Transform>();




	public Transform First_Set;
	public Transform Second_Set;
	public Transform Third_Set;

	public Transform Box_Set_End;
	public Transform Box_Set_Endloop;

	public Transform Box_Set_0_0_0;
	public Transform Box_Set_1_1_1;
//	public Transform Box_Set_1_1_2;
	public Transform Box_Set_1_2_1;
//	public Transform Box_Set_1_2_2;
	public Transform Box_Set_1_3_1;
//	public Transform Box_Set_1_3_2;
	public Transform Box_Set_1_4_1;
//	public Transform Box_Set_1_4_2;
	public Transform Box_Set_1_5_1;
//	public Transform Box_Set_1_5_2;
	public Transform Box_Set_1_6_1;
//	public Transform Box_Set_1_6_2;
	public Transform Box_Set_1_7_1;
//	public Transform Box_Set_1_7_2;
	public Transform Box_Set_1_8_1;
//	public Transform Box_Set_1_8_2;
	public Transform Box_Set_1_9_1;

	List<Transform> BoxsetList_1_1 = new List <Transform>();
	List<Transform> BoxsetList_1_2 = new List <Transform>();
	List<Transform> BoxsetList_1_3 = new List <Transform>();
	List<Transform> BoxsetList_1_4 = new List <Transform>();
	List<Transform> BoxsetList_1_5 = new List <Transform>();
	List<Transform> BoxsetList_1_6 = new List <Transform>();
	List<Transform> BoxsetList_1_7 = new List <Transform>();
	List<Transform> BoxsetList_1_8 = new List <Transform>();
	List<Transform> BoxsetList_1_9 = new List <Transform>();



	void Awake () 
	{	
		
		
		BoxsetList_1_1.Add (Box_Set_0_0_0);
		BoxsetList_1_2.Add (Box_Set_0_0_0);
		BoxsetList_1_3.Add (Box_Set_0_0_0);
		BoxsetList_1_4.Add (Box_Set_0_0_0);
		BoxsetList_1_5.Add (Box_Set_0_0_0);
		BoxsetList_1_6.Add (Box_Set_0_0_0);
		BoxsetList_1_7.Add (Box_Set_0_0_0);
		BoxsetList_1_8.Add (Box_Set_0_0_0);
		BoxsetList_1_9.Add (Box_Set_0_0_0);


		BoxsetList_1_1.Add (Box_Set_1_1_1);
//		BoxsetList_1_1.Add (Box_Set_1_1_2);
		BoxsetList_1_2.Add (Box_Set_1_2_1);
//		BoxsetList_1_2.Add (Box_Set_1_2_2);
		BoxsetList_1_3.Add (Box_Set_1_3_1);
//		BoxsetList_1_3.Add (Box_Set_1_3_2);
		BoxsetList_1_4.Add (Box_Set_1_4_1);
//		BoxsetList_1_4.Add (Box_Set_1_4_2);
		BoxsetList_1_5.Add (Box_Set_1_5_1);
	//	BoxsetList_1_5.Add (Box_Set_1_5_2);
		BoxsetList_1_6.Add (Box_Set_1_6_1);
//		BoxsetList_1_6.Add (Box_Set_1_6_2);
		BoxsetList_1_7.Add(Box_Set_1_7_1);
		BoxsetList_1_8.Add(Box_Set_1_8_1);
		BoxsetList_1_9.Add(Box_Set_1_9_1);
		/* Final level long ting
		BoxsetList_1_7.Add (Box_Set_1_1_1);
//		BoxsetList_1_7.Add (Box_Set_1_1_2);
		BoxsetList_1_7.Add (Box_Set_1_2_1);
//		BoxsetList_1_7.Add (Box_Set_1_2_2);
		BoxsetList_1_7.Add (Box_Set_1_3_1);
		BoxsetList_1_7.Add (Box_Set_1_4_1);
	//	BoxsetList_1_7.Add (Box_Set_1_4_2);
		BoxsetList_1_7.Add (Box_Set_1_5_1);
//		BoxsetList_1_7.Add (Box_Set_1_5_2);
		BoxsetList_1_7.Add (Box_Set_1_6_1);
	
*/
		BoxsetList_1_1.Add (Box_Set_End);
		BoxsetList_1_2.Add (Box_Set_End);
		BoxsetList_1_3.Add (Box_Set_End);
		BoxsetList_1_4.Add (Box_Set_End);
		BoxsetList_1_5.Add (Box_Set_End);
		BoxsetList_1_6.Add (Box_Set_End);
		BoxsetList_1_7.Add (Box_Set_End);
		BoxsetList_1_8.Add (Box_Set_End);
		BoxsetList_1_9.Add (Box_Set_End);

		BoxsetList_1_1.Add (Box_Set_Endloop);
		BoxsetList_1_2.Add (Box_Set_Endloop);
		BoxsetList_1_3.Add (Box_Set_Endloop);
		BoxsetList_1_4.Add (Box_Set_Endloop);
		BoxsetList_1_5.Add (Box_Set_Endloop);
		BoxsetList_1_6.Add (Box_Set_Endloop);
		BoxsetList_1_7.Add (Box_Set_Endloop);
		BoxsetList_1_8.Add (Box_Set_Endloop);
		BoxsetList_1_9.Add (Box_Set_Endloop);


			

		if (Level_Manger.current_level == 1) 
		{
			PrefabBoxsetList = BoxsetList_1_1;
		}
		if (Level_Manger.current_level == 2) 
		{
			PrefabBoxsetList = BoxsetList_1_2;

		}

		if (Level_Manger.current_level == 3) 
		{
			PrefabBoxsetList = BoxsetList_1_3;
		}
		if (Level_Manger.current_level == 4) 
		{
			PrefabBoxsetList = BoxsetList_1_4;
		}
		if (Level_Manger.current_level == 5) 
		{
			PrefabBoxsetList = BoxsetList_1_5;
		}
		if (Level_Manger.current_level == 6) 
		{
			PrefabBoxsetList = BoxsetList_1_6;
		}
		if (Level_Manger.current_level == 7) 
		{
			PrefabBoxsetList = BoxsetList_1_7;
		}
		if (Level_Manger.current_level == 8) 
		{
			PrefabBoxsetList = BoxsetList_1_8;
		}

		if (Level_Manger.current_level == 9) 
		{
			PrefabBoxsetList = BoxsetList_1_9;
		}








		Instantiate(PrefabBoxsetList[0],First_Set.transform.position, Quaternion.identity);

		Instantiate(PrefabBoxsetList[1],Second_Set.transform.position, Quaternion.identity);

		Instantiate(PrefabBoxsetList[2],Third_Set.transform.position, Quaternion.identity);
		next = 2;

		GameObject[] Box_Set = GameObject.FindGameObjectsWithTag("Box_Sets");

		foreach(GameObject Box_Sets in Box_Set) 
		{
			Vector2 pos = Box_Sets.transform.position;
			Box_Sets.transform.position = pos;
		}

	}
	public void RestartPositions()
	{
		if (Level_Manger.current_level == 1) 
		{
			PrefabBoxsetList = BoxsetList_1_1;
		}
		if (Level_Manger.current_level == 2) 
		{
			PrefabBoxsetList = BoxsetList_1_2;

		}

		if (Level_Manger.current_level == 3) 
		{
			PrefabBoxsetList = BoxsetList_1_3;
		}
		if (Level_Manger.current_level == 4) 
		{
			PrefabBoxsetList = BoxsetList_1_4;
		}
		if (Level_Manger.current_level == 5) 
		{
			PrefabBoxsetList = BoxsetList_1_5;
		}
		if (Level_Manger.current_level == 6) 
		{
			PrefabBoxsetList = BoxsetList_1_6;
		}
		if (Level_Manger.current_level == 7) 
		{
			PrefabBoxsetList = BoxsetList_1_7;
		}
		if (Level_Manger.current_level == 8) 
		{
			PrefabBoxsetList = BoxsetList_1_8;
		}

		if (Level_Manger.current_level == 9) 
		{
			PrefabBoxsetList = BoxsetList_1_9;
		}
/////////////////////////////////		
		Second_Set.position = new Vector3 ((First_Set.position.x + width_of_boxs), Second_Set.position.y, Second_Set.position.z);
		Third_Set.position = new Vector3 ((Second_Set.position.x + width_of_boxs), Second_Set.position.y, Second_Set.position.z);
		
		GameObject[] Box_Set_to_destroy = GameObject.FindGameObjectsWithTag("Box_Sets");

		foreach(GameObject Box_Sets2 in Box_Set_to_destroy) 
		{
//			print ("Ran");
			Destroy (Box_Sets2);
		}
		Finished_Main_Cycle = false;
		Instantiate(PrefabBoxsetList[0],First_Set.transform.position, Quaternion.identity);

		Instantiate(PrefabBoxsetList[1],Second_Set.transform.position, Quaternion.identity);

		Instantiate(PrefabBoxsetList[2],Third_Set.transform.position, Quaternion.identity);
		next = 2;

		GameObject[] Box_Set = GameObject.FindGameObjectsWithTag("Box_Sets");

		foreach(GameObject Box_Sets in Box_Set) 
		{
			Vector2 pos = Box_Sets.transform.position;
			Box_Sets.transform.position = pos;
		}




	}
	void OnTriggerEnter2D(Collider2D collider) 
	{

		if(collider.tag == "SET")
		{
			
			Vector2 pos = collider.transform.position;
			pos.x += width_of_boxs * numpanels;
		
			collider.transform.position = pos;


			if ((PrefabBoxsetList[next] == Box_Set_End)||(Finished_Main_Cycle))
			{
				
				Finished_Main_Cycle = true;

				Instantiate(Box_Set_Endloop,collider.transform.position, Quaternion.identity);
			}
			else 
				
			{
				next += 1;
				
				Instantiate(PrefabBoxsetList[next],collider.transform.position, Quaternion.identity);
			}
		}

		if (collider.tag == "Box_Sets") 
		{
			Destroy (collider.gameObject);

		}
		
	}

}
