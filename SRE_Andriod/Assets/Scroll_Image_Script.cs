using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scroll_Image_Script : MonoBehaviour 
{

	public Text text;

	public RectTransform panal; // to hold the scroll panal
	public Image[] Img;
	public RectTransform center; // center to compar the distance for each button

	RectTransform RectTrans;

	// private variables
	private float[] distance; // all butons distance to the center
	private bool dragging = false; //will be true, which they drag;
	private int ImgDistance; // will hold the distance between the buttons
	private int minButtonNum ; // To hold the number of the button, with smallest distance to centre



	void Start()
	{
		dragging = true;
		dragging = false;
		int ImgLength = Img.Length;
		distance = new float[ImgLength];


		// Get distance betweeen buttons




		ImgDistance = (int)Mathf.Abs(Img[1].GetComponent<RectTransform>().anchoredPosition.x - Img[0].GetComponent<RectTransform>().anchoredPosition.x);
	}
	void Update()
	{
		for (int i = 0; i < Img.Length; i++) 
		{
			distance [i] = Mathf.Abs (center.transform.position.x - Img [i].transform.position.x);
		}

		float minDistance = Mathf.Min (distance);

		for (int a = 0; a < Img.Length; a++) 
		{
			if (minDistance == distance [a]) 
			{
				minButtonNum = a;

			}
		}
		if (!dragging) 
		{
			LerptoImg(minButtonNum * -ImgDistance);
		}
		text.GetComponent<Text> ().text = Img [minButtonNum].name;

		for (int b = 0; b < Img.Length; b++)
		{
			if (b == minButtonNum) 
			{
				Img [b].GetComponent<Animator> ().SetBool ("Selected", true);

			} 
			else 
			{
				//Img [b].GetComponent<Animator> ().enabled = false;
				Img [b].GetComponent<Animator> ().SetBool ("Selected", false);
			}


		}
	}

	void LerptoImg (int position)
	{
		float newX = Mathf.Lerp (panal.anchoredPosition.x, position, Time.deltaTime * 5f);
		Vector2 newPosition = new Vector2 (newX, panal.anchoredPosition.y);

		panal.anchoredPosition = newPosition;
	}

	public void SlideRight ()
	{
		if (minButtonNum != (Img.Length -1)) 
		{
			Vector2 newPosition = new Vector2 ((panal.anchoredPosition.x - ImgDistance), panal.anchoredPosition.y);
			panal.anchoredPosition = newPosition;
			LerptoImg (minButtonNum * -ImgDistance);
		}
	}
	public void SlideLeft ()
	{
		if (minButtonNum != 0)
		{
			Vector2 newPosition = new Vector2 ((panal.anchoredPosition.x + ImgDistance), panal.anchoredPosition.y);
			panal.anchoredPosition = newPosition;
			LerptoImg(minButtonNum * -ImgDistance);
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