using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Prize_menu_controller : MonoBehaviour {

	public GameObject Screen1;
	public GameObject Screen2;
	public SoundPlayer soundPlayer;
	// camera  
	public Transform camera_trans;
	public Camera Camera_camera;
	public Product_Manger PM;
	public GameObject Victim;

	public GameObject sprakParticles;

	public Animator mystreyCrateAnim;

	float yvelocity = 0.0f;
	float zoomVecolity = 0.0f;
	public float posSmoothTime = 0.3f;
	public float orginalYPosition;
	public float zoomYPosition;
	public float orginalZoomSize;
	public float zoomSize;
	public float zoomSmoothTime = 0.3f;
	bool zoomIn;
	bool zoomOut  =false;
	 


	void Start () {
		Vector3 pos = camera_trans.transform.position;
		camera_trans.transform.position = pos;
	//	RewardOpenStage ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (zoomIn) {
			
			Vector3 pos = camera_trans.transform.position;
			pos.y = zoomYPosition;

			float newposition = Mathf.SmoothDamp (camera_trans.position.y, pos.y, ref yvelocity, posSmoothTime);
			camera_trans.position = new Vector3 (camera_trans.position.x, newposition, camera_trans.position.z);


			float newSize = Mathf.SmoothDamp (Camera_camera.GetComponent<Camera>().orthographicSize, zoomSize, ref zoomVecolity, zoomSmoothTime);
		//	float newSize = Mathf.Lerp (orginalZoomSize, zoomSize, zoomSmoothTime);
			Camera_camera.GetComponent<Camera>().orthographicSize = newSize;

			if ((Mathf.Approximately(camera_trans.position.y,pos.y))&&(Mathf.Approximately(Camera_camera.GetComponent<Camera>().orthographicSize, zoomSize))) 
			{
			//	yvelocity = 0.0f;
			//	zoomVecolity = 0.0f;
				zoomIn = false;
				print ("end");
				RewardCloseStage ();
			}	
		}
		if (zoomOut) {

			Vector3 pos = camera_trans.transform.position;
			pos.y = orginalYPosition;

			float newposition = Mathf.SmoothDamp (camera_trans.position.y, pos.y, ref yvelocity, posSmoothTime);
			camera_trans.position = new Vector3 (camera_trans.position.x, newposition, camera_trans.position.z);

			float newSize = Mathf.SmoothDamp (Camera_camera.GetComponent<Camera>().orthographicSize, orginalZoomSize, ref zoomVecolity, zoomSmoothTime);
			Camera_camera.GetComponent<Camera>().orthographicSize = newSize;

			if ((Mathf.Approximately(camera_trans.position.y,pos.y))&&(Mathf.Approximately(Camera_camera.GetComponent<Camera>().orthographicSize, orginalZoomSize))) 
			{
			//	yvelocity = 0.0f;
			//	zoomVecolity = 0.0f;
				zoomOut = false;
			}	
		}
			
	}
	public void RewardOpenStage()
	{
		// Play Opening sound
		soundPlayer.Play_PrizeOpening();
		zoomOut = false;
		// this will be called after flash
		Victim.GetComponent<Animator>().enabled = true;
		Victim.GetComponent<SpriteRenderer> ().enabled = true;
		if (!PM.duplicate) {
			sprakParticles.SetActive (true);
		}
		// make character appear
		Victim.GetComponent<Victim_Movement>().Switch_Costume();
		// switch costumes
		mystreyCrateAnim.enabled = false;
		// turn on animation of mystrey body first

		// make panal disapper as a whole
		zoomIn = true;
		// it will zoom in down onto the character place
		Screen1.SetActive (false);
		Screen2.SetActive (true);
		// make panal disapper and show clearly the character 
		// show particles


	}


	public void RewardCloseStage()
	{
		zoomIn = false;	
		zoomOut = true;
		sprakParticles.SetActive(false);
		print ("retun costume");
		PlayerPrefs.SetInt("Character_Skin", PM.currentCostume);
		Victim.GetComponent<Victim_Movement>().Switch_Costume();
		Victim.GetComponent<Animator>().enabled = false;
		Victim.GetComponent<SpriteRenderer> ().enabled = false;
		//make character disapper (by image only (optional))
		Screen1.SetActive (true);
		Screen2.SetActive (false);
		// turn on panal
		mystreyCrateAnim.enabled = true;
		// turn on mystrey box animation
		zoomOut = true;
		// after a tap on screen zoom out 

		// make mystery crate panal appear again

	}
	public void LeaveRewardMenu()
	{
		
		Camera_camera.GetComponent<Camera>().orthographicSize = orginalZoomSize;
		camera_trans.position = new Vector3 (camera_trans.position.x, orginalYPosition, camera_trans.position.z);


	}

/*	void AlterVisability ( bool Visible)

	{
		if (Visible == true) {
			// make stuff invisible
		}
		if (Visible == false) {
			// make stuff invisible
		}
		
	}
	*/
}
