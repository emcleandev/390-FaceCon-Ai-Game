using UnityEngine;
using System.Collections;

public class background_scroller : MonoBehaviour {
	public bool bottom;
	public float speed = 0;
	public static background_scroller current;

	float pos = 0;

	void Start () 
	{
		current = this;

	}

	void Update()
	{
		if (bottom)
			pos += speed;
		else
			pos -= speed;
		if (pos > 1.0f)
			pos -= 1.0f;

		GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (pos, 0);

	}
}