#pragma strict

var target : float;
var smoothTime = 0.3;
private var thisTransform : Transform;
private var velocity : Vector2;

function Start()
{
	thisTransform = transform;
}

function Update() 
{
	thisTransform.position.y = Mathf.SmoothDamp( thisTransform.position.y, 
		target, velocity.y, smoothTime);
	
}