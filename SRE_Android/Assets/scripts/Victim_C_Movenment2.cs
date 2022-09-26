using UnityEngine;
using System.Collections;

public class Victim_C_Movenment2 : MonoBehaviour {

	
	
	Animator anim;
	public float TimesJumped = 1;
	public float jumpForce = 100f;
	public float maxSpeed = 1f;
	float groundRadius = 0.2f;
	public Transform groundCheck;
	public LayerMask WhatIsGround;
	public LayerMask WhatIsDeathzone;
	bool grounded = false;
	public bool dead = false;
//	bool godMode = false;
	float deathCooldown;
	bool deathzone= false;
	// Update is called once per frame
	
	void Start ()
	{
		print ("start");
		anim = GetComponent<Animator> ();
	}
	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, WhatIsGround);
		deathzone = Physics2D.OverlapCircle (groundCheck.position, groundRadius, WhatIsDeathzone);
		
		anim.SetBool("Grounded", grounded);
		
		
		print("Grounded");
		GetComponent<Rigidbody2D>().velocity = new Vector2 (1 * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		
		if (dead) {
			Application.LoadLevel( Application.loadedLevel );
		}
	}
	
	
	void Update () 
	{
		
		if (deathzone) 
		{
			anim.SetTrigger("Death");
			dead = true;
			deathCooldown = 0.5f;
		}
		if (dead) 
		{
			print ("dead");
			deathCooldown -= Time.deltaTime;
			print ("Attempt to return");
			Application.LoadLevel (Application.loadedLevel);
		}
		
		if(((Input.touchCount == TimesJumped)||(Input.GetKeyDown(KeyCode.Space) )|| Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0) && (grounded))
		{
			
			
			GetComponent<Rigidbody2D>().AddForce( Vector2.up * jumpForce );
			
			print ("Just jumped");
			TimesJumped += 1;
			print (TimesJumped);
			
		}
		
		
		
	}
}