using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterChecker : MonoBehaviour {
	private static CounterChecker instance;
	public static CounterChecker Instance{get{ return instance;}}
	public static int scorePrev;
	public int counter;

	// Use this for initialization
	void Start () {
		scorePrev = -1;
		if (instance == null) {
			instance = this;
			counter = -4;
			setStone ();
		}
		else {
			Destroy (gameObject);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if(col.CompareTag("dodo")){
			if (counter>=4) {
			//if(GameManager.Instance.score == scorePrev){
				newDodoMovement.target = 3;
				GameManager.Instance.inPlay = false;
				UIHandlerGameMenu.Instance.Gameover ();
				print("GameOver");
			}	
		}
	}

	void OnTriggerExit(Collider col){
		
		if (col.CompareTag ("dodo")) {
			//scorePrev = GameManager.Instance.score;

			counter++;
			setStone ();
		}
	}
	public void setStone(){
		if (counter >=4) {
			gameObject.transform.GetChild (0).gameObject.SetActive (true);
		} else {
			gameObject.transform.GetChild (0).gameObject.SetActive (false);
		}
	}
}
