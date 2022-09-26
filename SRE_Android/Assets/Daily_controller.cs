using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Daily_controller : MonoBehaviour {

	public DateTime lastReset;
	DateTime dueResets;
	Manger Mansc;
	public Text timer;
	DateTime tempDuedate;
	void Awake()
	{
		dueResets = new DateTime (2016, 04, 29, 0, 0, 0);
		Mansc = gameObject.GetComponent<Manger> ();
	}


	void Start () {
		//TryResetChallenge ();
		print (lastReset.Date);
		print (lastReset.TimeOfDay);
		if( Application.loadedLevel == 0)
		{
			checkForReset();
		}
	
	
	}
	

	public void checkForReset () {
		print ("chhhecck");
		if (DateTime.Now.Date != lastReset.Date) {
			
			TryResetChallenge ();
			print ("Attempting to reset_challenge");
		}
			
	
		}


	void TryResetChallenge()
	{
		//levels completed 1
		if (Application.loadedLevel == 1) {
			Application.LoadLevel (0);
		}
		else {

			lastReset = new DateTime (DateTime.Now.Date.Year,DateTime.Now.Date.Month,DateTime.Now.Date.Day,0,0,0);
			Mansc.resetChallenge ();
			//reset levels completed
			// reset stars of each level

			//simply reset everything and the timer


			// the data should be reset
		}


	
	}
	void Update()
	{
		
		dueResets = lastReset.AddDays (1);
		dueResets.AddDays(1);


			
		if (Application.loadedLevel == 0 && DateTime.Now.Date != lastReset.Date) {
			checkForReset ();
		
	}
		// Timer
		double hours = Math.Round((dueResets- DateTime.Now).TotalHours);

//		print (hours);
		if ((dueResets - DateTime.Now).Hours <= 0) {
			double mins = (dueResets - DateTime.Now).Minutes;
			if (Application.loadedLevel == 0) {
				timer.text = mins + "mins left";
			}
		} else {
			if (Application.loadedLevel == 0) {
				timer.text = hours + "hrs left";
			}

		}

		

}
}

/*
tempDuedate = new DateTime (lastReset.Year, lastReset.Month, lastReset.Day, dueResets.Hour, dueResets.Minute, dueResets.Second);
if (Application.loadedLevel == 0 && (tempDuedate - DateTime.Now).Minutes < 0) {
	checkForReset ();
}

if (lastReset.Hour > 3) {
	//		print ("adding day");
	//			print (tempDuedate);
	tempDuedate=  tempDuedate.AddDays (01);
	//		print (tempDuedate);
}
double hours = Math.Round((tempDuedate - DateTime.Now).TotalHours);

print (hours);
if ((tempDuedate - DateTime.Now).Hours <= 0) {
	double mins = (tempDuedate - DateTime.Now).Minutes;
	if (Application.loadedLevel == 0) {
		timer.text = mins + "mins left";
	}
} else {
	if (Application.loadedLevel == 0) {
		timer.text = hours + "hrs left";
	}

}
print (((DateTime.Compare(tempDuedate,DateTime.Now)) < 0));
print ((DateTime.Compare(tempDuedate,DateTime.Now)));
print (tempDuedate.Date);
print (tempDuedate.TimeOfDay);
*/