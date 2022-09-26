using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	Transform VictimTrans; 
	Transform SpawnPointTrans;



	void Start () {
		VictimTrans = GameObject.FindGameObjectWithTag ("Player").transform;
		SpawnPointTrans = GetComponent<Transform> ();
//		print (SpawnPointTrans.position);

		VictimTrans.position = SpawnPointTrans.position; 
		
		
	
	}
	

	void Update () {
	
	}
}
