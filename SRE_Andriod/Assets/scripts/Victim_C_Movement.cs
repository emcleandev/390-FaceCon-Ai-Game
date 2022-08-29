using UnityEngine;
using System.Collections;

public class Victim_C_Movement : MonoBehaviour {

	Animator anim;
	public float TimesJumped = 1;
	public float jumpForce = 100f;
	public float leapForce = 100f;
	public float maxSpeed = 1f;
	float groundRadius = 1.3f;
	public Transform groundCheck;
	public LayerMask WhatIsGround;
	public LayerMask WhatIsDeathzone;
	bool grounded = false;
	public bool dead = false;
//	bool godMode = false;
//	float deathCooldown;
	bool deathzone= false;
	public float Originalbegincountdown = 7f;
	float begincountdown;

	// Update is called once per frame
	
	void Start ()
	{
		print ("start");
		anim = GetComponent<Animator> ();
		begincountdown = Originalbegincountdown;
	}
	void FixedUpdate () 
	{
			grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, WhatIsGround);
			deathzone = Physics2D.OverlapCircle (groundCheck.position, groundRadius, WhatIsDeathzone);
	
			anim.SetBool ("Grounded", grounded);
			begincountdown -= Time.deltaTime;

	
			GetComponent<Rigidbody2D>().velocity = new Vector2 (1 * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
	
			if (dead)  
			{
					
					Application.LoadLevel (Application.loadedLevel);
			}
			
			
	}
	public void Touched (bool Touched)
	{
		print ("touch");
		if ((Swipe_Dectection.Swiped_up)&&(grounded))
		{
			print ("player wants to pass through up , you did it, now celebrate with music");
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * leapForce);
			Swipe_Dectection.Swiped_up = false;
			Swipe_Dectection.Swiped_down = false;
			Touched = false;
			Swipe_Dectection.Swiped = false;
		}
		if ((Swipe_Dectection.Swiped_down)&& (grounded))
		{
			print ("player wants to pass through down, you did it, now celebrate with music");
			Swipe_Dectection.Swiped_down = false;
			Swipe_Dectection.Swiped_up = false;
			Touched = false;
			Swipe_Dectection.Swiped = false;
		}
		else
		{

			if ((Touched) && (grounded) && !(Swipe_Dectection.Swiped)) 
			{
				print ("jump");
				GetComponent<Rigidbody2D>().AddForce (Vector2.up * jumpForce);
				Touched = false;			
			}
		}
	}
	void Update () 
	{
		if ((GetComponent<Rigidbody2D>().velocity == Vector2.zero )&& (begincountdown <= 2) ) 
		{
			print ("dead");
			print ("Attempt to return");
			dead = true;
		}
		if (GetComponent<Rigidbody2D>().velocity != Vector2.zero)
		{
			begincountdown = Originalbegincountdown;

		}

		 
		if (deathzone) 
		{
			anim.SetTrigger("Death");
			dead = true;
//			deathCooldown = 5f;
		}



	
		

}
}