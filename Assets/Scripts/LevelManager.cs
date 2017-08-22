using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

/// <summary>
/// Level Manager handles scene transitions.
/// </summary>
public class LevelManager : MonoBehaviour 
{	
	/// <summary>
	/// Loads the next level while closing all other scenes.
	/// </summary>
	/// <param name="nextScene"> The name of the next scene that 
	///  	needs to be loaded. Accepted through the Inspector. </param>
	public void LoadLevel(string nextScene)
	{		
		// On load to the next scene
		SceneManager.LoadScene(nextScene);
	}
}
