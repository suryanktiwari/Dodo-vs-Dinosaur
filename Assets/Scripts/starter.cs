using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class starter : MonoBehaviour {

	public GameObject camera1;
	public GameObject camera2;

	void Start () {
		Invoke ("start",4.70f);
		Invoke ("switcher", 2.5f);
	}
		
	void start()
	{
		SceneManager.LoadScene ("Home");
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
			start ();
	}

	void switcher()
	{
		camera1.SetActive (false);
		camera2.SetActive (true);
	}
}
