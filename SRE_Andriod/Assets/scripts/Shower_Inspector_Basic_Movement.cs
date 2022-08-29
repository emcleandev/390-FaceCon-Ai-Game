using UnityEngine;
using System.Collections;

public class Shower_Inspector_Basic_Movement : MonoBehaviour {
	public float maxSpeed = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (1 * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
	
	}
}
