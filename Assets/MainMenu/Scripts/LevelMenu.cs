using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelMenu : MonoBehaviour {



	public void StartForestLevel () // method to be assigned in unity Button Onclick
	{
		SceneManager.LoadScene (1);

	}

	public void StartCityLevel () // method to be assigned in unity Button Onclick
	{
		SceneManager.LoadScene (2); 

	}
}
