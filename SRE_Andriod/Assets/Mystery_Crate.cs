using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mystery_Crate : MonoBehaviour {

	public bool Flash = false;
	public Prize_menu_controller PrizeManager;
	public GameObject Manger;
	public GameObject MysteryCrateButton;
	public GameObject QuestionText;
	public GameObject ExcalamtionText;
	public Button Open_button;
//	Animator anim;
	Animation Amation;
	public float Wait_time = 0f;
	bool Avaliable = true;
	void Start () {
		
//		anim = GetComponent<Animator> ();
		Amation = GetComponent<Animation> ();
		//PlayerPrefs.SetInt ("Star_Currency", 100);


	}


	void FixedUpdate () 
	{
		if (Flash) 
		{
			print ("tried");
			Flash = false;
			Manger.GetComponent<Manger> ().Flash_fade (Color.white);
			print ("tried2");

			Amation.Play("MysteryCrate idle2");
			ResetText ();
		//	StartCoroutine (BeginOpening2());
			MysteryCrateButton.GetComponent<Button> ().interactable = true;
			PrizeManager.RewardOpenStage();

		}
	}


	public void BeginOpening ()
	{
//		StartCoroutine (Button_Cooldown());
		Open_button.interactable=false;
		Amation.Play("Mystery Crate");

	//	anim.SetBool ("Fresh_begin", false);


	}
	public void TrickReset()
	{
		MysteryCrateButton.GetComponent<Button> ().interactable = true;
	}
		
	IEnumerator BeginOpening2()
	{
		MysteryCrateButton.GetComponent<Button> ().interactable = false;
		if (Avaliable) 
		{
			Avaliable = false;     
			yield return new WaitForSeconds (Wait_time);

			Avaliable = true;
		}
		Open_button.interactable=false;
	}
/*	IEnumerator Button_Cooldown()
	{
		

	//	MysteryCrateButton.GetComponent<Animator> ().enabled = false;
		yield return new WaitForSeconds (3f);

	//	MysteryCrateButton.GetComponent<Animator> ().enabled = true;
	

	}
	*/
	void ResetText()
	{
		QuestionText.SetActive (true);
		QuestionText.GetComponent<Text> ().color = Color.white;
		ExcalamtionText.GetComponent<Text> ().color = Color.white;
		ExcalamtionText.SetActive (false);
		print ("ran");
	}


}
