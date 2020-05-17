using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newDinoMovement : MonoBehaviour {

	public GameObject dino;
	public bool animating;
	public AudioSource aSource;

	// Use this for initialization
	void Start () {
		animating = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.inPlay) {
			dino.transform.RotateAround (dino.transform.position, -Preloader.Instance.rotationType*Vector3.up, 80f * Time.deltaTime);
			if (!animating) {
				animating = true;
				gameObject.GetComponent<Animator> ().SetBool ("repeat", true);
				print ("set repeat");
			}
			if (Input.GetMouseButtonDown (0)) {
//				print ("dino rotation is " + dino.transform.rotation.eulerAngles);
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("dodo")){
			GameManager.Instance.inPlay = false;
		}

	}

	public void complete(int stat){
		if (stat == 1) {
			animating = false;
		}
	}

	public void Gameover(){

		UIHandlerGameMenu.Instance.Gameover ();
		gameObject.GetComponent<Animator> ().SetBool ("gameover", false);
		gameObject.GetComponent<Animator> ().SetBool ("start", true);
		print ("called");
	}
	public void soundBajado(){
		if (Preloader.Instance.soundStatus == 1) {
			aSource.PlayOneShot (Preloader.Instance.squishSound);
		}
	}

	public void setParams(){
		gameObject.GetComponent<Animator> ().SetBool ("gameover", false);
		gameObject.GetComponent<Animator> ().SetBool ("start", false);
		gameObject.GetComponent<Animator> ().SetBool ("repeat", false);
		print ("params");
	}
}
