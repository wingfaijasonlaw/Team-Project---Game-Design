using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUpDeath : MonoBehaviour {

	public int meat;
	public int veg;

	/// <summary>
	/// Score class to access its methods
	/// </summary>
	private Score mainScore;

	private UnityEngine.TextMesh text;

	// Use this for initialization
	void Start () 
	{
		text = this.GetComponent <UnityEngine.TextMesh>();
		text.text = "";
		// Finds the GameObject, Score in the Scene
		GameObject go = GameObject.Find("Score");
		// Get Score's script
		mainScore = (Score) go.GetComponent(typeof(Score));
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "meat") 
		{
			meat += 1;

			// Display collection
			text.color = Color.red;
			text.text = "-1";
			Invoke ("Clear", 0.5f);

			// Decrement the main score by 1
			mainScore.UpdateScore(-1);
			Destroy (other.gameObject);
		} 
		else if (other.gameObject.tag == "veg") 
		{
			veg += 1;

			// Display collection
			text.color = Color.green;
			text.text = "+1";
			Invoke ("Clear", 0.5f);

			// Increment the main score by 1
			mainScore.UpdateScore(+1);
			Destroy (other.gameObject);
		} 	
	}


	// Helper method to clear collection display
	void Clear()
	{
		text.text = "";
	}
}
