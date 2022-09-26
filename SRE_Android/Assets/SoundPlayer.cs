using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {

	public AudioClip ButtonSound;
	public AudioClip DenySound;
	public AudioClip PrizeSound1, PrizeSound2;
	private AudioSource source;
	int tempNoPrizePlays;

	void Awake()
	{
		source = GetComponent<AudioSource> ();

	}


	void Update () {

		if (Manger.OnMute) 
		{
			source.mute = true;
		}
		else
		{
			source.mute = false;
		}
	
		}


	public void Play_buttonSound () 
	{	
		
		source.PlayOneShot (ButtonSound, 1f);
	}

	public void Play_DenySound () 
	{	
		source.PlayOneShot (DenySound, 1f);
	}

	public void Play_PrizeOpening()
	{
		tempNoPrizePlays++;
		if (tempNoPrizePlays % 2 == 0) {
			source.PlayOneShot (PrizeSound1, 1f);

		} else {
			source.PlayOneShot (PrizeSound2, 1f);
		}
			
		
	}


}
