using UnityEngine;
using System.Collections;

public class HatController : MonoBehaviour 
{
	public Camera cam;
	private float maxWidth;
	
	void Start () 
	{
		if(cam==null)
			cam = Camera.main;
		Vector3 upperCorner = new Vector3(Screen.width,Screen.height,0.0f);
		var targetWidth = cam.ScreenToWorldPoint(upperCorner);
		float hatWidth = renderer.bounds.extents.x;
		maxWidth = targetWidth.x-hatWidth;
	
	}
	
	void FixedUpdate () {
		var rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
		var targetPosition = new Vector3(rawPosition.x,0.0f,0.0f);
		float targetWidth = Mathf.Clamp (targetPosition.x,-maxWidth,maxWidth);
		targetPosition = new Vector3(targetWidth,targetPosition.y,targetPosition.z);
		rigidbody2D.MovePosition(targetPosition);
	}
}
