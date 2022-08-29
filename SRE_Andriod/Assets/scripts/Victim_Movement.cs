using UnityEngine;
using System.Collections;

public class Victim_Movement : MonoBehaviour {

	int Costume_number;

	Animator anim;
	public int maxNoCostumes;

	float NewJumpforce;
	float initialJumpForce;
	public int TimesJumped = 1;
	public float jumpForce = 100f;
	public float leapForce = 100f;
	public float maxSpeed = 1f;
	float groundRadius = 1.3f;
	float PresenceRadius = 0.3f;

	public Transform groundCheck;
	public Transform PresenceCheck;
	public Transform above_P_check;
	public Transform below_P_check;

	public float topy;
	public float midy;
	public float boty;

	public LayerMask WhatIsGround;
	public LayerMask WhatIsPurpleCrate;
	public LayerMask WhatIsBlueCrate;
	public LayerMask WhatIsDeathzone;
	public LayerMask WhatIsAbove;
	public LayerMask WhatIsBelow;
	public LayerMask WhatIsTopset;
	public LayerMask WhatIsTopC2set;
	public LayerMask WhatIsBottomset;

	public static bool Topset = false;
	public static bool Bottomset = false;
	public static bool Cabove = false;
	public static bool Cbelow = false;
	public static bool TopC2set = false;
	bool grounded = false;

	public  bool dead = false;


	float deathCooldown;

	bool Purple_crate_check = false;
	bool Blue_crate_check = false;

	bool deathzone= false;
	public float Originalbegincountdown;
	float begincountdown;
	public float Box_distance;

	bool played = false; // plays death sound

	public bool  No_veleoctiy_by_Death  = false;
    public Transform cameraTarget;
    int direction = 1;
	public AudioClip LeapSound;
	public AudioClip JumpSound;
	public AudioClip CollectCoinSound;
	public AudioClip DeathSound;
	private AudioSource source;

	public GameObject Mangerobject;

    Rigidbody2D rigid;
   
	void Awake()
	{
		anim = GetComponent<Animator> ();
		source = GetComponent<AudioSource> ();
        rigid = GetComponent<Rigidbody2D>();
	}

	void Start ()

    {
       
        No_veleoctiy_by_Death  = false;
		dead = false;

//		print (PlayerPrefs.GetInt("Character_Skin"));
		Switch_Costume ();
	//	Vector2 newVelocity;
		No_veleoctiy_by_Death = false;

		anim = GetComponent<Animator> ();
		begincountdown = Originalbegincountdown;
		Vector2 pos = rigid.transform.position;
		rigid.transform.position = pos;
        runForward();
	}

    public void runForward()
    {
        if (Manger.Level_Ended)
        {
            return;
        }
        direction = 1;
        Vector3 temp = new Vector3(cameraTarget.position.x, Mathf.Abs(cameraTarget.position.y), cameraTarget.position.z);

        cameraTarget.position = temp;
        transform.rotation = Quaternion.Euler(0, 0, 0);

    }

    public void runBackward()
    {
        if (Manger.Level_Ended)
        {
            return;
        }
        direction = -1;
        Vector3 temp = new Vector3(cameraTarget.position.x, Mathf.Abs(cameraTarget.position.y) * -1, cameraTarget.position.z);
       
        cameraTarget.position = temp;
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    void FixedUpdate () 
	{
        
			
		deathzone = Physics2D.OverlapCircle (groundCheck.position, groundRadius, WhatIsDeathzone);
		Purple_crate_check = Physics2D.OverlapCircle (groundCheck.position, groundRadius, WhatIsPurpleCrate);
		Blue_crate_check = Physics2D.OverlapCircle (groundCheck.position, groundRadius, WhatIsBlueCrate);

		if (Purple_crate_check) {
			print ("Working");
		}

		Cabove = Physics2D.OverlapCircle (above_P_check.position, PresenceRadius, WhatIsAbove);
		Cbelow = Physics2D.OverlapCircle (below_P_check.position, PresenceRadius, WhatIsBelow);

		Topset = Physics2D.OverlapCircle (PresenceCheck.position, PresenceRadius, WhatIsTopset);
		Bottomset = Physics2D.OverlapCircle (PresenceCheck.position, PresenceRadius, WhatIsBottomset);
		TopC2set = Physics2D.OverlapCircle (PresenceCheck.position, PresenceRadius, WhatIsTopC2set);

		anim.SetBool ("Grounded", grounded);

		
		if ((!dead)||(!No_veleoctiy_by_Death))
		{
			rigid.velocity = new Vector2 (direction * 1 * maxSpeed, rigid.velocity.y);
            
		
		}

	
		if (deathzone) 
		{

			dead = true;
			print ("death by deathzone");
			Victim_Died();
		}

	}
	public void Jump ()
	{
        if (Manger.Level_Ended)
        {
            return;
        }

        print("JUMP!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
		if  (grounded) 
		{
     		print ("jump");

			grounded = false;
			Vector2 newVelocity = rigid.velocity;
			newVelocity.y = 0f;
			source.PlayOneShot(JumpSound,1f);

			rigid.velocity = newVelocity;
			if (Purple_crate_check) 
			{
				NewJumpforce = Purple_Crate_Script.FinalPJumpForce;
				print (NewJumpforce);
				initialJumpForce = jumpForce;
				jumpForce = NewJumpforce;
				rigid.AddForce ((Vector2.up * jumpForce));
				jumpForce = initialJumpForce;
			} 
			else
			{
				rigid.AddForce ((Vector2.up * jumpForce));
			}				
		}

	}



	void Victim_Died(){
		
		
		if (!played)
		{
			source.PlayOneShot(DeathSound,1);
			played = true;
		}
		Mangerobject.GetComponent<Manger>().End_Level (false);

	}

	public void Leap_Up ()
	{
        if (Manger.Level_Ended)
        {
            return;
        }
        if (!Blue_crate_check)
		{
			if ((Topset)||(TopC2set)) 
			{
				return;
			}
			if (Cabove) {
				return; // if cant jump above then cant leap up because of gap
			}
			else 
			{
				grounded = false;
				print ("leap up");
				source.PlayOneShot(LeapSound,1);
				rigid.velocity = Vector2.zero;
				Vector2 pos = rigid.transform.position;
				pos = rigid.transform.position;
				if (Bottomset)
					pos.y = midy;
				else
					pos.y = topy;


				rigid.transform.position = pos;


			}
		}
	}
	public void Leap_Down ()
	{
        if (Manger.Level_Ended)
        {
            return;
        }
        if (!Blue_crate_check)
		{
			if (Bottomset) 
			{
				return;
			} 
			if (Cbelow) {
				return; // if cant jump below then cant leap down because of gap
			}
			else 
			{	
				grounded = false;
				print ("leap down");
				source.PlayOneShot(LeapSound,1);
				rigid.velocity = Vector2.zero;
				Vector2 pos = rigid.transform.position;
				pos = rigid.transform.position;
				if (Topset)
					pos.y = midy;
				else
					pos.y = boty;

				rigid.transform.position = pos;
			}

			
		}
	}



	void  Update () 
	{
        
        if (rigid.velocity.x != 0)
        {
            print("doesnt equal zero");
            begincountdown = Originalbegincountdown;


        }
        else
        {
            
            begincountdown -= Time.deltaTime;
        }

        grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, WhatIsGround);


		int nbTouches = Input.touchCount;
		
		if(nbTouches > 0)
		{
			for (int i = 0; i < nbTouches; i++)
			{
				Touch touch = Input.GetTouch(i);
				
				if(touch.phase == TouchPhase.Began )
				{
					print ("screen touched");
			//		Touched();
				}
			}

		}
		if (Manger.OnMute) 
		{
			source.mute = true;
		}
		else
		{
			source.mute = false;
		}
		

		if (( rigid.velocity.x == Vector2.zero.x )&& (begincountdown >= 100)&&(!No_veleoctiy_by_Death) ) 
		{
			print ("death by no velocity");
			dead = true;
			Victim_Died();

		}



		
	}


	public void Restart_Countdown_for_gamerestart()
	{	
		played = false;
		begincountdown = 5f;
	}


	void OnCollisionEnter2D(Collision2D collider) {

		if(collider.gameObject.tag == "Spike")
		{
//			print ("spike");
//			print ("death by spike");
			dead = true;
			Victim_Died();
		}

	}
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "orb") 
		{
			Score.AddPoint ();
			source.PlayOneShot (CollectCoinSound, 1);
			Destroy (collider.gameObject);

		
			
		}
		if (collider.gameObject.tag == "Up push crate") 
		{
			Debug.Log ("leap from crate");
			Leap_Up ();
	}
		if (collider.gameObject.tag == "Down push crate") 
		{
			Debug.Log ("leap from crate");
			Leap_Down ();
		}

}
	public void Switch_Costume(){
		Costume_number = PlayerPrefs.GetInt("Character_Skin");

		for (int a = 0; a <= maxNoCostumes; a++) {
			if (a == Costume_number) {
				
				string tempString = a.ToString () + "_skin"; 
				anim.SetBool (tempString, true);
			} else {
				string tempString = a.ToString () + "_skin"; 
				anim.SetBool (tempString, false);
			}
		}
				



}
}