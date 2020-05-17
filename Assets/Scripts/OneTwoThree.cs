using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OneTwoThree : MonoBehaviour {

	public GameObject ott,pause,preventTouch;
	private int stat;
	public float startTime;

	// Use this for initialization
	void Awake () {
		stat = 0;
		pause.SetActive (false);
		preventTouch.SetActive (true);
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0)) {
			StopAllCoroutines ();
			ott.transform.GetChild (stat).gameObject.SetActive (false);
			gameObject.GetComponent<Animator> ().Play ("skipped_anim");
			preventTouch.SetActive (false);
			pause.SetActive (true);
			//StartCoroutine ("play");
		}

	}

	public void showOne(){
		StopAllCoroutines ();
		ott.gameObject.transform.GetChild (stat).gameObject.SetActive (false);
		ott.gameObject.transform.GetChild (2).gameObject.SetActive (true);
		stat = 2;
		StartCoroutine ("fade");
	}

	public void showTwo(){
		StopAllCoroutines ();
		ott.gameObject.transform.GetChild (stat).gameObject.SetActive (false);
		ott.gameObject.transform.GetChild (1).gameObject.SetActive (true);
		stat = 1;
		StartCoroutine ("fade");
	}

	public void showThree(){
		ott.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		stat = 0;
		StartCoroutine ("fade");
	}

	public void disable(){
		preventTouch.SetActive (false);
		StopAllCoroutines ();
		pause.SetActive (true);
		ott.gameObject.transform.GetChild (stat).gameObject.SetActive (false);
		GameManager.Instance.inPlay = true;
		this.GetComponent<OneTwoThree> ().enabled = false;
	}

	IEnumerator fade(){
		Vector3 scl = ott.gameObject.transform.GetChild (stat).localScale;
		while (true) {
			scl = ott.gameObject.transform.GetChild (stat).localScale = new Vector3 (scl.x + 0.01f, scl.y + 0.01f, scl.z);
			yield return new WaitForEndOfFrame ();
		}
	}

	IEnumerator play(){
		yield return new WaitForSeconds (0.5f);
		GameManager.Instance.inPlay = true;
		this.GetComponent<OneTwoThree> ().enabled = false;
	}
}
