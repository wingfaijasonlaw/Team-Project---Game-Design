using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the Main Score functionality and visuals
/// </summary>
public class Score : MonoBehaviour {
	/// <summary>
	/// Accesses the Text box in Inspector to update
	///	the player's score as the game progresses
	/// </summary>
	public Text scoreText;

	/// <summary>
	/// PlayerMotor class to access methods 
	/// </summary>
	private PlayerMovement playerMvmt;

	/// <summary>
	/// Current score of the Player and is initially set to
	///	zero at the start of the game.
	/// </summary>
	private int score;
	/// <summary>
	/// Tracks when player is dead, so that the Score stops
	/// being updated
	/// </summary>
	private bool isDead = false;

	/// <summary>
	/// Unity Start Method for Instantiations
	/// </summary>
	void Start () 
	{		
		playerMvmt 		= GetComponent<PlayerMovement>();
		// Set score to zero initially
		score 			= 0;
		// Update the score visual box
		scoreText.text 	= score.ToString();
		// Change score text to white, on zero
		scoreText.color = Color.white;
	}

	/// <summary>
	/// Invoked when the Player is dead. 
	/// </summary>
	public void OnDeath()
	{
		isDead = true;
	}//End of OnDeath()

	/// <summary>
	/// Updates the score itself and the score's visuals.
	/// </summary>
	/// <param name="gameObjectPoints">The amount of points the 
	///									game object was worth.</param>
	public void UpdateScore(int gameObjectPoints)
	{
		// Don't update the score, if the player is dead
		if (isDead) return;

		// Change the score
		score += gameObjectPoints;
		// Update the score box
		scoreText.text = score.ToString();

		// Update colors
		// Floor is used when the score is between (0,1)
		if (Mathf.Floor(score) == 0)
		{// Zero, set to white
			scoreText.color = Color.white;
		} 
		else if (score > 0)
		{// Positive score, set to green
			scoreText.color = Color.green;
		}
		else if (score < 0)
		{// Negative score, set to red
			scoreText.color = Color.red;
		}//End of Update Colors
	}//End of UpdateScore()

	/// <summary>
	/// Gets the score.
	/// </summary>
	/// <returns>The score.</returns>
	/// 
	public int GetScore()
	{
		return score;
	}//End of GetScore()
}
