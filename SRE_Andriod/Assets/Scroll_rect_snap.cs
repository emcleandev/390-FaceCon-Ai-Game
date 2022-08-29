using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scroll_rect_snap : MonoBehaviour 
{

	public Text text;

	public RectTransform panal; // to hold the scroll panal
	public Button[] bttn;
	public Color[] Textcolours;
	public RectTransform center; // center to compar the distance for each button
	public Button left_button;
	public Button right_button;
	RectTransform RectTrans;

	// private variables
	private float[] distance; // all butons distance to the center
	private bool dragging = false; //will be true, which they drag;
	private int bttnDistance; // will hold the distance between the buttons
	private int minButtonNum ; // To hold the number of the button, with smallest distance to centre



	void Start()
	{
		dragging = true;
		dragging = false;
		int bttnLength = bttn.Length;


		// Get distance betweeen buttons



		bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.x - bttn[0].GetComponent<RectTransform>().anchoredPosition.x);
		distance = new float[bttnLength];

		int temp =PlayerPrefs.GetInt ("Character_Skin"); // number of places to being at
		Vector2 newPosition = new Vector2 ((panal.anchoredPosition.x +(temp * -bttnDistance)), panal.anchoredPosition.y);
		panal.anchoredPosition = newPosition;

		print ("HEee");


	}
	void Update()
	{
		for (int i = 0; i < bttn.Length; i++) 
		{
			distance [i] = Mathf.Abs (center.transform.position.x - bttn [i].transform.position.x);
		}

		float minDistance = Mathf.Min (distance);

		for (int a = 0; a < bttn.Length; a++) 
		{
			if (minDistance == distance [a]) 
			{
				minButtonNum = a;

			}
		}
		if (!dragging) 
		{
			LerptoBttn(minButtonNum * -bttnDistance);
		}
		text.GetComponent<Text> ().text = bttn [minButtonNum].name;
		text.GetComponent<Text> ().color = Textcolours [minButtonNum];
		left_button.image.color = Textcolours [minButtonNum];
		right_button.image.color = Textcolours [minButtonNum];

		for (int b = 0; b < bttn.Length; b++)
		{
			if (b == minButtonNum) 
			{
				bttn [b].GetComponent<Animator> ().SetBool ("Selected", true);

			} 
			else 
			{
				//bttn [b].GetComponent<Animator> ().enabled = false;
				bttn [b].GetComponent<Animator> ().SetBool ("Selected", false);
			}
				
	
		}

			

}


	

	void LerptoBttn (int position)
	{
		float newX = Mathf.Lerp (panal.anchoredPosition.x, position, Time.deltaTime * 3f);
		Vector2 newPosition = new Vector2 (newX, panal.anchoredPosition.y);

		panal.anchoredPosition = newPosition;
	}

	public void SlideRight ()
	{
		if (minButtonNum != (bttn.Length -1)) 
		{
			Vector2 newPosition = new Vector2 ((panal.anchoredPosition.x - bttnDistance), panal.anchoredPosition.y);
			panal.anchoredPosition = newPosition;
			LerptoBttn (minButtonNum * -bttnDistance);
		}
	}
	public void SlideLeft ()
	{
		if (minButtonNum != 0)
		{
			Vector2 newPosition = new Vector2 ((panal.anchoredPosition.x + bttnDistance), panal.anchoredPosition.y);
			panal.anchoredPosition = newPosition;
			LerptoBttn(minButtonNum * -bttnDistance);
		}
	}
	public void StartDrag()
	{
		dragging = true;
	}
	public void EndDrag()
	{
		dragging = false;
	}

		
}