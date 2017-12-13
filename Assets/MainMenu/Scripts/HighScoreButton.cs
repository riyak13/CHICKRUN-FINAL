using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class HighScoreButton : MonoBehaviour {

	public string HighScore; 

	public void LoadStoryHighScore ()
	{
		SceneManager.LoadScene (HighScore);
	}
}
