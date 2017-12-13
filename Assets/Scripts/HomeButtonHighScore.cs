using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class HomeButtonHighScore : MonoBehaviour {

	public string HomeButton; 

	public void LoadMainMenu ()
	{
		SceneManager.LoadScene (HomeButton);
	}
}
