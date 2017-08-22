using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles
/// </summary>
public class GameManager : MonoBehaviour 
{
	/// <summary>
	/// The death message of the LoseMenu panel.
	/// </summary>
	public Text deathText;
	/// <summary>
	/// The lose panel gameObject in Scene.
	/// </summary>
	public GameObject losePanel_go;
	/// <summary>
	/// The Score class to access its score.
	/// </summary>
	private Score score;

	void Start()
	{
		// Find the GameObject, Score in Scene
		GameObject go_score = GameObject.Find("Score");
		// Get the script of the game object, Score
		score = (Score) go_score.GetComponent("Score");
	}//END OF Start()

	/// <summary>
	/// Invoked when the player dies. This will handle other game
	/// objects that need to stop or be invoked on player death.
	/// </summary>
	public void OnDeathPause()
	{
		// Pull the Lose Menu from hiding
		losePanel_go.SetActive(true);

		//TODO Stop the cars from moving without using Time.scale = 0

		// Based on the type of score, death message is slightly different
		int playerScore = score.GetScore();
		if (playerScore >= 0)
		{// If score is positive, they were mainly eating vegetables
			deathText.text = "You ate " + playerScore + " vegetables.";
		}
		else				
		{// If score is negative, they were mainly eating meat
			deathText.text = "You ate " + Mathf.Abs(playerScore) + " meat.";		
		}//End of if playerScore is pos/neg
	}//END OF OnDeathPause()
}
