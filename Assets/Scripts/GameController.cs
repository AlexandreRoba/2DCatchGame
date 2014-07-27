using UnityEngine;

using System.Collections;

public class GameController : MonoBehaviour 
{
	public Camera cam;
	public GameObject ball;
	private float maxWidth;
	public float timeLeft;
	public UILabel timerText;
	
	void Start () 
	{
		if(cam==null)
			cam = Camera.main;
		Vector3 upperCorner = new Vector3(Screen.width,Screen.height,0.0f);
		var targetWidth = cam.ScreenToWorldPoint(upperCorner);
		float ballWidth = ball.renderer.bounds.extents.x;
		maxWidth = targetWidth.x-ballWidth;
		StartCoroutine(Spawn ());
		updateTimer ();
	}
	
	void FixedUpdate()
	{
		timeLeft -= Time.deltaTime;
		if(timeLeft<0)
			timeLeft = 0;
		updateTimer();
	}
	
	IEnumerator Spawn()
	{
		yield return new WaitForSeconds(2.0f);
		while(timeLeft>0){
			Vector3 spawnPosition = new Vector3(Random.Range(-maxWidth,maxWidth),transform.position.y,0.0f);
			Quaternion spawRotation = Quaternion.identity;
			Instantiate (ball,spawnPosition, spawRotation);
			yield return new WaitForSeconds(Random.Range (1.0f,2.0f));
		}
	}
	
	void updateTimer()
	{
		if(timerText!=null)
		{
			timerText.text ="Time Left:\n" + Mathf.RoundToInt(timeLeft).ToString();
		}
	}
}
