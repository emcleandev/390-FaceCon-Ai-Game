using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scene_Fade_Script : MonoBehaviour {

	public RawImage Fade;
	public float PrizeDelay_time;
	int FadeDirection= -1;
	public float Fade_speed = 2f;
	public float Delay_time = 0.5f;
	float alpha_change = 1.0f;
	bool Delay_over = false;
//	bool code_Trick = true;
//	void OnGui()
//	{

//		alpha += FadeDir * fadeSpeed * Time.deltaTime;

//		alpha = Mathf.Clamp01 (alpha);

//		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
//		GUI.depth = drawDepth;
//		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
//	}


//	public float BeginFade (int direction)
//	{
//		FadeDir = direction;
//		return (fadeSpeed);
//	}

//	void OnLevelWasLoaded (){

//		BeginFade (-1);v
//	}

	void awake()
	{
		//Fade.color = new Color (Fade.color.r, Fade.color.g, Fade.color.b, 1);
	}
	void Start () {

		StartCoroutine (Delay ());


	
	}
//	public void TrickFade()
//	{
//		Delay_over = false;
//		alpha_change = 0;
//		Fade.color = Color.white;
//		StartCoroutine (Delay ());
//	}

	public float BeginFade(int direction, Color Color__)
	{
		

		if (direction == -1) 
		{
			Fade.enabled = true;
			alpha_change = 255;
//			print ("Bitch where");
			Delay_over = false;


		}
		Fade.color = new Color (Color__.r, Color__.g, Color__.b, alpha_change);
		FadeDirection = direction;

		if (direction == -1) 
		{
			StartCoroutine (PrizeDelay ());
		}
		return (Fade_speed);
	}

	IEnumerator PrizeDelay()
	{
		Fade.enabled = true;
		yield return new WaitForSeconds (PrizeDelay_time);
		Delay_over = true;
	}
		
	IEnumerator Delay ()
	{
		
		Fade.enabled = true;
		yield return new WaitForSeconds (Delay_time);
		Delay_over = true;

	}
	void Update () {



		if (Delay_over)  
		{	
			
			alpha_change += FadeDirection * Fade_speed * Time.deltaTime;
			alpha_change = Mathf.Clamp01 (alpha_change);

		
			Fade.color = new Color (Fade.color.r, Fade.color.g, Fade.color.b, alpha_change);

		}


		if (Fade.color.a > 0.1) {

			Fade.enabled = true;
		} 
		else {
			Fade.enabled = false;

			FadeDirection = 0;

		}		
	}
}
