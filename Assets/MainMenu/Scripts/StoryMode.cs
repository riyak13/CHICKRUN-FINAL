using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class StoryMode : MonoBehaviour {

	public string Story; 

	public void LoadStory ()
	{
		SceneManager.LoadScene (Story);
	}
}
