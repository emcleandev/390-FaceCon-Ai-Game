using UnityEngine;
using System.Collections;

public class Score_Orb_Point : MonoBehaviour {

	//public Transform CollectorCheck;
//	public LayerMask WhatIsCollector;
//	bool N_Collector = false;
	//float OrbRadius = 0.1f;
	//int Score_given = 0; 
	//public AudioSource victim_source;
	//public AudioClip CollectCoinSound;
	void Start()
	{
		
	}
	
	void FixedUpdate ()
	{
		//N_Collector = Physics2D.OverlapCircle (CollectorCheck.position, OrbRadius, WhatIsCollector);
	}
	
	void OnTriggerEnter2D(Collider2D collider) 
	{
		if (collider.tag == "orb") {
			print ("add");
		//	Score.AddPoint ();
//			victim_source.PlayOneShot(CollectCoinSound,1);
	//		Destroy (gameObject);

		}
	}
//		 void Update()
//	{		if (N_Collector)
//		{
//			if (Score_given < 1)
//			{
//				Score.AddPoint();
//				print ("1 poin");
//				N_Collector = false;
//				Destroy(gameObject);
//			}
			
//		}
//	}
	
}