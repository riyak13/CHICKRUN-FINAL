using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void ExitGame ()  // exit game platform, when game is actually loaded 
	{
		Debug.Log ("Exit!");
		Application.Quit ();
	}

}
