using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour 
{
	private BoxCollider2D backgroundCollider;  
	private float backgroundHorizontalLength; 


	void Start () 
	{
		backgroundCollider = GetComponent<BoxCollider2D> ();   //add boxcollider to the background image
		backgroundHorizontalLength = backgroundCollider.size.x; // the length of the background image
			
		
	}
	

	void Update () 
	{
		if (transform.position.x < -backgroundHorizontalLength) //define when to start scrolling: before the second image scrolls off screen to the left
		{
			repositionBackground ();
		}
		
	}


	private void repositionBackground()
	{
		Vector2 backgroundOffset = new Vector2 (backgroundHorizontalLength * 2f, 0); //offset X: 2f by the length of the background image, Y: 0
		transform.position = (Vector2)transform.position + backgroundOffset; 
	}





}
