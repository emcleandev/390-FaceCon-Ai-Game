using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level_Text_Fade_control : MonoBehaviour {

	public Level_Manger lvlManager;
	public Text lvlText;
	public Text score;

	public float Delay_time = 0.5f;
	float alpha_change = 1.0f;
	public float fadeSpeed;
	int FadeDirection = -1;
	bool Delay_over = false;
	Shadow[] txtShadows;
	void Start () {
		begin_state ();
	}
	
	public void begin_state()
	{
		lvlText.gameObject.SetActive (true);
		if (Level_Manger.current_level == 1) {
			lvlText.text = "Open Mouth\nto Jump\n";
		} else if (Level_Manger.current_level == 2) {
			lvlText.text = "Look Up & Down\nto Leap";
		} else {
			lvlText.text = "Level " + Level_Manger.current_level;
		}
		lvlText.color = new Color (lvlText.color.r, lvlText.color.g, lvlText.color.b, 1f) ;
		txtShadows = lvlText.gameObject.GetComponents<Shadow>();
		foreach (Shadow shad in txtShadows) {
			shad.effectColor = new Color (shad.effectColor.r, shad.effectColor.g, shad.effectColor.b, 0.5f);
		}
		alpha_change = 1.0f;
		StartCoroutine( Delay ());


	}


	IEnumerator Delay ()
	{
		Delay_over = false;

		yield return new WaitForSeconds (Delay_time);
		Delay_over = true;

	}

	void Update()
	{
		if (Delay_over) {
			alpha_change += FadeDirection * fadeSpeed * Time.deltaTime;
			alpha_change = Mathf.Clamp01 (alpha_change);

			lvlText.color = new Color (lvlText.color.r, lvlText.color.g, lvlText.color.b, alpha_change);

		}
		if (lvlText.color.a < 0.9) {
			txtShadows = lvlText.gameObject.GetComponents<Shadow> ();
			foreach (Shadow shad in txtShadows) {
				shad.effectColor = new Color (shad.effectColor.r, shad.effectColor.g, shad.effectColor.b, 0f);
			}
		}	

		if (lvlText.color.a > 0.1) {
			lvlText.gameObject.SetActive (true);
			score.gameObject.SetActive (false);
		} else {
			
			lvlText.gameObject.SetActive (false);
			score.gameObject.SetActive (true);
		}
	}
}
