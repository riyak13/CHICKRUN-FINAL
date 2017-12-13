using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseMenu : MonoBehaviour 
{
	GameObject[] pauseMenuObjects;

	void Start()
	{
		Time.timeScale = 1; // when game is playing, hide pause menu
		pauseMenuObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		HidePaused ();
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			if (Time.timeScale == 1) // when game is running, and Space key is pressed, pause game and show pause menu
			{
				Debug.Log ("show");
				Time.timeScale = 0;
				ShowPaused ();
			} else if (Time.timeScale == 0)  // when game is paused and Space key is pressed, hide pause menu and resume game play
			{
				Debug.Log ("hide");
				Time.timeScale = 1;
				HidePaused ();
			}
		}
	}


	public void ShowPaused() // when game paused, show pause menu, pause game music
	{
		foreach (GameObject gameobject in pauseMenuObjects) 
		{
			gameobject.SetActive (true);
			SoundManager.instance.MusicSource.Stop ();
		}
	}

	public void HidePaused() // when game in play, hide pause menu, play game music
	{
		foreach (GameObject gameobject in pauseMenuObjects) 
		{
			gameobject.SetActive (false);
			SoundManager.instance.MusicSource.Play ();
		}
	}

	public void PauseResume() //method assigned to Resume Button Onclick in unity
	{
		if (Time.timeScale == 1)  
		{
			Time.timeScale = 0;
			ShowPaused ();
		} else if (Time.timeScale == 0) // when game is paused, and Resume Button is clicked, resume game play
		{
			Time.timeScale = 1;
			HidePaused ();
		}
	}

	public void RestartGame() // method assigned to Restart Button Onclick
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex); //Reload same level game
		SoundManager.instance.MusicSource.Play (); // play music
	}




	public void LoadMainMenu()  // // method assigned to MainMenu Button Onclick
	{
			SceneManager.LoadScene (0);	 //when Button is click, load Main Menu 
		SoundManager.instance.MusicSource.Play ();

	}









}
