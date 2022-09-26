using UnityEngine;
using System.Collections;

public class backgroundfollow : MonoBehaviour {

    public Transform target;
    public float smoothTime = 0.3f;
    private Transform thisTransform;
    private Vector2 velocity;
    float x;
    // Use this for initialization
    void Start () {
        thisTransform = transform;
	
	}
	
	// Update is called once per frame
	void Update () {
        
            float x = Mathf.SmoothDamp(
            thisTransform.position.x,
            target.position.x, ref velocity.x, smoothTime);

        Vector3 tempVect = thisTransform.position;
        thisTransform.position = new Vector3(x, tempVect.y, tempVect.z);



    }
}
