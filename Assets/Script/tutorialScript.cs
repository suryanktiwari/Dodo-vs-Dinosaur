using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class tutorialScript : MonoBehaviour {

	public VideoClip a, b, c;

	private int progress;

	void Start()
	{
		progress = 0;
		GetComponent<VideoPlayer> ().clip = a;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) {
			next ();
		}
	}

	public void next()
	{
		switch (progress) {
		case 0:
			progress++;
			GetComponent<VideoPlayer> ().clip = b;
			break;
		case 1: 
			progress++;
			GetComponent<VideoPlayer> ().clip= c;
			break;
		case 2:
			skip ();
			break;
		}
	}

	public void skip()
	{
		SceneManager.LoadScene ("main");
	}
}
