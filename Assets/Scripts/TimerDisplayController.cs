using UnityEngine;
using System.Collections;

public class TimerDisplayController : MonoBehaviour 
{
	GameController gameController;
	UILabel label;

	void Awake()
	{
		gameController = FindObjectOfType(typeof(GameController)) as GameController;
		label = GetComponent<UILabel>();
	}

	void Start ()
	{
	
	}
	
	void FixedUpdate ()
	{
		label.text = gameController.timeLeft.ToString("0");
	}
}
