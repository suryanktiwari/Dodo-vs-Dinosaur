using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour {
	
	public Transform[] panelList;
	public Text buttonNext;
	public GameObject Next;
	// Use this for initialization
	public GameObject dodo, dino;
	public GameObject protectivePanel;
	int panelNo;
	int initialPanelNo;
	int endPanelNo;
	float startTime;

	void Start () {
		if (Preloader.Instance.tutorial == 0) {
			gameObject.SetActive (false);

		} else {

			Preloader.Instance.tutorial = 0;
		}
		initialPanelNo = 0;
		endPanelNo = panelList.Length-1;
		WorkPanelStart ();

	}

	public void OnNext(){
		if (panelNo == endPanelNo) {
			gameObject.SetActive (false);
			return; 
		} else if (panelNo == endPanelNo - 1) {
			buttonNext.text = "Exit";
		}
		panelList [panelNo].gameObject.SetActive (false);
		panelNo++;
		panelList [panelNo].gameObject.SetActive (true);
		WorkPanelStart ();
		print ("panel no is"+panelNo);
	}

	void Update () {
		if (dodo == null || dino == null) {
			dodo = GameObject.FindGameObjectWithTag ("dodo").transform.parent.gameObject;
			dino = GameObject.FindGameObjectWithTag ("dinosaur");
			Preloader.Instance.rotationType = -1;
			dino.GetComponent<Animator> ().speed = 0f;
		}
		WorkPanelUpdate ();
	
	}

	void WorkPanelStart(){
		startTime = Time.time;
		switch (panelNo) {
		case 0:
			protectivePanel.SetActive (true);
			Next.SetActive (false);
			break;
		case 1:
			protectivePanel.SetActive (true);
			Time.timeScale = 1f;
			break;
		}
	}

	void WorkPanelUpdate(){
		switch (panelNo) {
		case 0:
			if (Time.time - startTime < 5f) {
				return;
			} 
			protectivePanel.SetActive (false);
			dodo.transform.parent.rotation = Quaternion.Euler (new Vector3 (0f, 194f, 0f));
			dodo.transform.position = new Vector3 (-4.5f, -0.5f, -2.1f);
			GameObject.Find ("endOne").transform.position = new Vector3 (-4.5f, -0.5f, -2.1f);
			GameObject.Find ("endTwo").transform.position = new Vector3 (4.5f, -0.5f, 2.1f);

			dino.transform.rotation = Quaternion.Euler (new Vector3 (0f, 50, 0f));
			Time.timeScale = 0f;


			if (Input.GetMouseButtonDown (0)) {
				OnNext ();
			}
			break;
		case 1:
			if (UIHandlerGameMenu.Instance.isGameOver) {
				SceneManager.LoadScene ("Home");
			}

			break;
		}
	}

}
