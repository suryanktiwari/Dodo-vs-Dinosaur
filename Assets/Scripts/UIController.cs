using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	public GameObject parentPanel;
	private int i;

	// Use this for initialization
	void Start () {
		//disable if already done
		i = 0;
		//set the counter variable
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void nextPanel(){
		if (i < 4) {
			i++;
			parentPanel.transform.GetChild (i).gameObject.SetActive (true);
			parentPanel.transform.GetChild (i - 1).gameObject.SetActive (false);
		} else {
			parentPanel.SetActive (false);
			//start game for the first time
		}
	}
}
