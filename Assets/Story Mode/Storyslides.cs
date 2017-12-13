using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Storyslides : MonoBehaviour
{
	GameObject[] story = new GameObject[3];
	//GameObject story2;
	//GameObject story3;
	int currentImage;
	GameObject back;
	GameObject forward;
	GameObject home;


	void Start () {
		story[0] = GameObject.Find ("Story1");
		story[1] = GameObject.Find ("Story2");
		story[2] = GameObject.Find ("Story3");
		currentImage = 0;
		back = GameObject.Find ("ButtonBack");
		forward = GameObject.Find ("ButtonForward");
		home = GameObject.Find ("ButtonHome");
		back.GetComponent<Button>().onClick.AddListener (() => goBack());
		forward.GetComponent<Button>().onClick.AddListener (() => goForward ());
		home.GetComponent<Button>().onClick.AddListener (() => goHome ());
	}

	void FixedUpdate () {
		for (int i = 0; i < 3; i++) {
			if (currentImage == i) {
				story [i].SetActive (true);
			} else {
				story [i].SetActive (false);
			}
		}
		if (currentImage == 0) {
			back.SetActive ( false);
			forward.SetActive ( true);
			home.SetActive ( false);
		}
		if (currentImage == 1) {
			back.SetActive ( true);
			forward.SetActive ( true);
			home.SetActive ( false);
		}
		if (currentImage == 2) {
			back.SetActive ( true);
			forward.SetActive ( false);
			home.SetActive ( true);
		}
	}

	public void goBack() {
		if (currentImage > 0) {
			currentImage--;
		}
	}

	public void goForward () {
		if (currentImage < 2) {
			currentImage++;
		}
	}

	public void goHome () {
		//  go back the main menu.
		SceneManager.LoadScene("MainMenu");
	}

}


