using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Swipe_Dectection : MonoBehaviour {
	private Vector3 fp;   //First touch position
	private Vector3 lp;   //Last touch position
	float dragDistance;  //minimum distance for a swipe to be registered
//	private List <Vector3> touchPositions = new List<Vector3>(); //store all the touch positions in list
	public static bool Swiped_up = false;	//if swiped down
	public static bool Swiped_down = false; //if swiped down
	public static bool Swiped = false;
	bool SwipeAvialiabe;
	public float dragMin = 0.5f;
	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;

	public Victim_Movement Playercontroller;
	void Start () {
		//dragDistance = 0f;//Screen.height*dragMin/100; //dragDistance is 20% height of the screen
		dragDistance = Screen.height*5/100; //dragDistance is 20% height of the screen
	}
	
	// Update is called once per frame
	void Update () {
		

			if(Input.touches.Length > 0)
			{
				Touch t = Input.GetTouch(0);
			if(t.phase == TouchPhase.Began )
			{
				print ("began touch");
					//save began touch 2d point
				firstPressPos = new Vector2(t.position.x,t.position.y);
			}
				
					//save ended touch 2d point
			secondPressPos = new Vector2(t.position.x,t.position.y);

			//create vector from the two points
			currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
			print (currentSwipe.y);
					//normalize the 2d vector
			Vector3 currentSwipe2 = currentSwipe;
			currentSwipe2.Normalize ();
			print (currentSwipe.y);
					//swipe upwards
			if(currentSwipe.y > dragDistance && currentSwipe2.x > -0.5f && currentSwipe2.x < 0.5f)
			{
				

				Debug.Log("up swipe");
				if (SwipeAvialiabe) {
					SwipeAvialiabe = false;
					print ("swipe leap UP");
					Playercontroller.Leap_Up ();
				}
			}
					//swipe down
			if(currentSwipe.y < -dragDistance && currentSwipe2.x > -0.5f &&  currentSwipe2.x < 0.5f)
			{
			//	print (currentSwipe.y);
				Debug.Log("down swipe");
				if (SwipeAvialiabe) {
					
					SwipeAvialiabe = false;
					print ("swipe leap Down");
					Playercontroller.Leap_Down ();
				}

			}
					//swipe left
			if(currentSwipe.x < 0 &&  currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
			{
				Debug.Log("left swipe");
			}
					//swipe right
			if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
				{
					Debug.Log("right swipe");
				}
			if (t.phase == TouchPhase.Ended)
				SwipeAvialiabe = true;
			
				
			}

	

	}
	
///////////////////////////////// previous version of Update	

}
