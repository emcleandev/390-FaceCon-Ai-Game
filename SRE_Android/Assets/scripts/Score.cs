using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour 
{

	public static int currentScore;
//	public int point_highscore_reached;
//	public bool highscore_reach = false;
//	public static int highscore;
	Text text; 
	Outline outline;
	
//	static Score instance;


	


	void Awake ()
	{

		outline = GetComponent <Outline> ();
		text = GetComponent <Text> ();		
		currentScore = 0;
//		instance = this;
	//	highscore = PlayerPrefs.GetInt("high score", 0);
//		point_highscore_reached = highscore;
	}
	static public void AddPoint() 
	{
		currentScore ++;
//		print (currentScore);
		
	//	if (score > highscore)
	//	{
	//		highscore = score;
	//		print (highscore);
	//	}
		
		
	}

				
	void Update ()
	{
		text.text = ""+ currentScore;

//		if ((highscore < score) &&! (highscore_reach))
//		{
//			point_highscore_reached = score;
//			highscore_reach = true;
//		}
	//	else
	//	{
		if (currentScore > 9) 
		{
			text.color = Color.yellow;
			outline.effectColor = Color.red;
		} 
		else 
		{
			text.color = new Color(1,(156f/255f),0,1);
			outline.effectColor = Color.red;	
		}


	///		else if (score > (4))
//			{

//				Color orange = new Color (0.985f,0.59f,0,1);
//				text.color = orange;
//				outline.effectColor = orange;

///			}

//			else if (score > (2))
//			{
//				text.color = Color.yellow;
//				outline.effectColor = Color.red;
//			}

	//	}


	}
//	void OnDestroy() {
//		instance = null;
//		PlayerPrefs.SetInt("Highscore", highscore);
//	}
}