using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chick : MonoBehaviour 
{
	
	private Rigidbody2D rgbd2d; //physic effect, to make chick fall and collide into other object with colliders
	private bool chickDead = false;  // Chick is not dead by default


	public float ForceUpward = 200f; // force for the chick to jump

	private Animator animator;


	void Start () 
	{
		rgbd2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}


	void Update () 
	{ if (chickDead == false) //when the game starts, the chick is not dead,  
		{ 		            
			animator.SetTrigger ("run");      //chick is contantly running by default			
			if (Input.GetMouseButtonDown (0))    //mouse button left click    // method to make the chick jump and fly
			{ 		                             
				rgbd2d.velocity = Vector2.zero;
				rgbd2d.AddForce (new Vector2 (0, ForceUpward));   // add force to make chick jump
				animator.SetTrigger ("fly");        // animation to show chick flying

			}
		}
	else if(chickDead == true) 
		{
		   transform.position = new Vector2 (0,-3); // when chick dies, it falls to the ground
		} 

	}



	void OnCollisionEnter2D (Collision2D coll) 			//chick collides onto different colliders
	{		
		if (coll.gameObject.name == "Berry" || coll.gameObject.name == "Water" || coll.gameObject.name == "grain" || coll.gameObject.name == "cherry") 
		{    // hit powerups to score
			GameControl.instance.RepositionCollider (coll.gameObject);
			GameControl.instance.ChickScored ();     // call method from game control to increase score and display
			SoundManager.instance.JumpSource.Play ();  // to play sound effect during game play
		   
		} else if (coll.gameObject.name == "Stone" || coll.gameObject.name == "Eagle") { //hit obstacles, chick dies
			chickDead = true;
			animator.SetTrigger ("die");   //animation to show chick dies
			GameControl.instance.ChickDead ();  // call method from game control to show game over and display game over message
			SoundManager.instance.MusicSource.Stop (); //stop background music when game over
			SoundManager.instance.GameOverSource.Play (); // to play gameover sound effect when game over

		}
	}



}












