using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_Controller : MonoBehaviour {

    public Victim_Movement player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            player.Jump();
        } else if (Input.GetKeyDown("up"))
        {
            player.Leap_Up();
        } else if (Input.GetKeyDown("down"))
        {
            player.Leap_Down();
        }
        else if (Input.GetKeyDown("left"))
        {
            player.runBackward();
        }else if (Input.GetKeyDown("right")){
            player.runForward();
        }
        else if (Input.GetKeyDown("p")){
            this.GetComponent<Manger>().run_Pause();
        }
        else if (Input.GetKeyDown("escape"))
        {
            try
            {
                Application.Quit();
                UnityEditor.EditorApplication.isPlaying = false;
            }
            catch (System.Exception e) {}
            
        }

    }
}
