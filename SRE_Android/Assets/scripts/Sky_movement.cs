using UnityEngine;
using System.Collections;

public class Sky_movement : MonoBehaviour {
	public float maxSpeed_sky = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2 (1 * maxSpeed_sky, GetComponent<Rigidbody2D>().velocity.y);
	
	}
}
