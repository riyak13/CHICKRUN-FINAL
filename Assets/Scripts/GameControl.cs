using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameControl : MonoBehaviour 
{
	public static GameControl instance; 

	public GameObject GameOverText; //canvas text to be shown under defined situations
	public Text ScoreText;   //to display score


	public bool GameOver = false;  // gameover is false by default

	private int score = 0;  //score starts with 0

	public float ScrollSpeed = -1.5f; // background scrolling speed



	void Awake () // before game start, check to make sure there is a game control
	{
		if (instance == null) 
		{
			instance = this;
		} 

	}



	void Update ()  
	{
		if (GameOver == true && Input.GetMouseButtonDown (0))  // when last game is over, and player left click mouse button
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex); //game restarts again (same level)
			SoundManager.instance.MusicSource.Play (); //background music plays
		} 
	}


	public void RepositionCollider(GameObject PowerupObject) //when a powerup object is collided by the chick, it gets repositionsed randomly
	{
		int repositionXMin = 10; //range for random reposition along the X axis
		int repositionXMax = 18;
		int repositionYMin = -5;   //range for random reposition along the Y axis
		int repositionYMax = 5;

		int repositionX = Random.Range (repositionXMin, repositionXMax);
		int repositionY = Random.Range (repositionYMin, repositionYMax);

		PowerupObject.transform.position = new Vector2(repositionX,repositionY);  //repositioned offscreen, ready to reappear when background scrolls

	}

	public void ChickScored ()    //increase and display score
	{
		if (GameOver) 
		{ 
			return;    // do not score when game over
		} else 
		{
			score = score + 100;     //increase score by 100 when hit a powerup object
			ScoreText.text = "Score: " + score.ToString (); // display the score when not gameover 
			                                                //score is int but it needs to be displayed as string text
		}
	
	}

	public void ChickDead()
	{
		GameOverText.SetActive (true); //display GAME OVER message when chick dies
		GameOver = true;

	}


}
