using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour 
{
	public UILabel scoreText;
	public int ballValue;
	
	private int score;
	
	// Use this for initialization
	void Start () {
		score=0;
		updateScoreText ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void updateScoreText ()
	{
		scoreText.text = "Score:\n" + Mathf.RoundToInt (score).ToString ();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		score += ballValue;
		updateScoreText(); 
	}
}
