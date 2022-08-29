using UnityEngine;
using System.Collections;

public class Camera_follow : MonoBehaviour {
	public Transform thisTransform;
	public GameObject Manger;
	public float Top_set_yaxis;
	public float Middle_set_yaxis;
	public float Bottom_set_yaxis;
	public float EndOFLevelYAxis;
	public float Top_2rowcondition_set_yaxis;
	float yvelocity = 0.0f;
	public float smoothTime = 0.3f;
	public float EndsmoothTime = 0.6f;
	public bool EndOfLEvelbool = false; 
	// Use this for initialization
	void Start () 
	{
		Vector3 pos = thisTransform.transform.position;
		thisTransform.transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if ( Manger.GetComponent<Manger>().Level_EndedCamera   == true) {
			Vector3 pos = thisTransform.transform.position;
			pos.y = EndOFLevelYAxis;

			float newposition = Mathf.SmoothDamp(thisTransform.position.y, pos.y, ref yvelocity, smoothTime);
			thisTransform.position = new Vector3 (thisTransform.position.x, newposition, thisTransform.position.z);
//			print ("third");
		}
		else
		{
			
			if (Victim_Movement.Topset)
			{
				Vector3 pos = thisTransform.transform.position;
				pos.y = Top_set_yaxis;

				float newposition = Mathf.SmoothDamp(thisTransform.position.y, pos.y, ref yvelocity, smoothTime);
				thisTransform.position = new Vector3 (thisTransform.position.x, newposition, thisTransform.position.z);
			}
			else if (Victim_Movement.Bottomset)
			{
				Vector3 pos = thisTransform.transform.position;
				pos.y = Bottom_set_yaxis;
				float newposition = Mathf.SmoothDamp(thisTransform.position.y, pos.y, ref yvelocity, smoothTime);
				thisTransform.position = new Vector3 (thisTransform.position.x, newposition, thisTransform.position.z);
			}
			else if (Victim_Movement.TopC2set)
			{
				Vector3 pos = thisTransform.transform.position;
				pos.y = Top_2rowcondition_set_yaxis;
				float newposition = Mathf.SmoothDamp(thisTransform.position.y, pos.y, ref yvelocity, smoothTime);
				thisTransform.position = new Vector3 (thisTransform.position.x, newposition, thisTransform.position.z);
			}

	
			else 
			{
				Vector3 pos = thisTransform.transform.position;
				pos.y = Middle_set_yaxis;
				float newposition = Mathf.SmoothDamp(thisTransform.position.y, pos.y, ref yvelocity, smoothTime);
				thisTransform.position = new Vector3 (thisTransform.position.x, newposition, thisTransform.position.z);
		}
	//		if (EndOfLEvelbool) {
	//			Vector3 pos = thisTransform.transform.position;
	//			pos.y = EndOFLevelYAxis;
	//			float newposition = Mathf.SmoothDamp(thisTransform.position.y, pos.y, ref yvelocity, EndsmoothTime);
	//			thisTransform.position = new Vector3 (thisTransform.position.x, newposition, thisTransform.position.z);
	//		}
	//		print (EndOfLEvelbool);

}
	}
	public void Restart_camera_position()
	{
		Vector3 pos = thisTransform.transform.position;
		pos.y = Bottom_set_yaxis;
		thisTransform.position = new Vector3 (thisTransform.position.x, pos.y, thisTransform.position.z);
	}

	}

