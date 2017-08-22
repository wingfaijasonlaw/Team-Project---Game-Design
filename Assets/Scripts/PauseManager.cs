using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

/// <summary> Pause Manager.
/// Handles opening/closing pause panel and functionality of pausing game.
/// </summary>
public class PauseManager : MonoBehaviour 
{	
	/// <summary>
	/// Pauses the game.
	/// </summary>
	/// <param name="pausePanel">GameObject Pause panel to open.</param>
	public void PauseGame(GameObject pausePanel)
	{
		// Freezes the clock timer
		Time.timeScale = 0;

		// Pull panel from hiding
		pausePanel.SetActive(true);
	}	

	/// <summary>
	/// Resumes the game.
	/// </summary>
	/// <param name="pausePanel">GameObject Pause panel to close.</param>
	public void ResumeGame(GameObject pausePanel)
	{
		// Resumes the clock timer back to realtime
		Time.timeScale = 1;

		// Sets panel back to hiding
		pausePanel.SetActive(false);
	}

	/// <summary>
	/// Goes back to the main menu while closing current scene.
	/// </summary>
	/// <param name="name">Name of the Main Menu.</param>
	public void BackToMainMenu(string name)
	{
		SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
		// Reset time back to realtime
		Time.timeScale = 1;
	}
}
