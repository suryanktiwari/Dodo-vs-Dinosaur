using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour {

	public static PlayerSelector Instance;
	//public GameObject notEnoughCoins;

	//use 1- trex 2- spino 3- dilo
	//use 1- normal 2- bat 3- punk
	public int dodoChar, dinoChar;

	// Use this for initialization
	void Start () {
		dodoChar = Preloader.Instance.dodo;
		dinoChar = Preloader.Instance.dino;
		SelectionController.Instance.setPanels ();

	}
	
	// Update is called once per frame
	void Update () {
		if (dinoChar != Preloader.Instance.dino) {
			Preloader.Instance.dino = dinoChar;
			Preloader.Instance.saveDodoDino ();
		}
		if (dodoChar != Preloader.Instance.dodo) {
			Preloader.Instance.dodo = dodoChar;
			Preloader.Instance.saveDodoDino ();
		}
	}

	public void setTrex(){
		dinoChar = 1;
		SelectionController.Instance.setPanels ();
		print ("trex");
	}


	public void setSpino(){
		if (Preloader.Instance.spino == 0) {
			if (Preloader.Instance.coins >= Constants.SpinoCost) {
				Preloader.Instance.subCoins (Preloader.Instance.coins - Constants.SpinoCost);
				dinoChar = 2;
				Preloader.Instance.unlockSpino ();
				print ("spino");
			}else{
				//display some text
//				StartCoroutine("display");
			}
		}else{
			dinoChar = 2;
			print ("spino");
		}
		SelectionController.Instance.setPanels ();
	}
		
	public void setDilo(){
		dinoChar = 3;
		SelectionController.Instance.setPanels ();
	}

	public void setNormal(){
		dodoChar = 1;
		SelectionController.Instance.setPanels ();
		print ("normal");
	}

	public void setBat(){
		if (Preloader.Instance.bat == 0) {
			if (Preloader.Instance.coins >= Constants.BatDodoCost) {
				Preloader.Instance.subCoins (Preloader.Instance.coins - Constants.BatDodoCost);
				dodoChar = 2;
				Preloader.Instance.unlockBat ();
				print ("bat");
			}else{
				//display text
				//StartCoroutine("display");
			}
		} else {
			dodoChar = 2;
			print ("bat");
		}
		SelectionController.Instance.setPanels ();

	}

	public void setPunk(){
		dodoChar = 3;
		SelectionController.Instance.setPanels ();

	}

	/*IEnumerator display(){
		notEnoughCoins.SetActive (true);
		yield return new WaitForSeconds (2f);
		notEnoughCoins.SetActive (false);
	}*/


}
