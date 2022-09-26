using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Jump_button: MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	
	private bool touched;
	private int pointerID;
	
	void Awake () {
		touched = false;
	}
	
	public void OnPointerDown(PointerEventData data) {
		if (!touched)
		{
			touched = true;
			pointerID = data.pointerId;
		}
	}
	
	public void OnPointerUp(PointerEventData data) {
		if (data.pointerId == pointerID)
			touched = false;
	}
	
	public bool IsTouched() 
	{

		return touched;
	}
}
