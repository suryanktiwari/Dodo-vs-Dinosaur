using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class newDodoMovement : MonoBehaviour {

	public GameObject parentObject,dodo,dino,counter,skull;
	public GameObject endOne, endTwo;
	public float radius;
	public static int target;
	private float speed,startTime;
	private GameObject[] posArray;
	public static bool inPlay;
	public AudioSource arSrc;
	public float theta;
	float OpenTime;

	// Use this for initialization
	void Start () {
		theta = Random.Range (0, 180)*Mathf.Deg2Rad;
		endOne.transform.position = new Vector3 (radius*Mathf.Cos(theta), -0.5f, radius*Mathf.Sin(theta));
		endTwo.transform.position = new Vector3 (-radius*Mathf.Cos(theta), -0.5f, -radius*Mathf.Sin(theta));
		posArray = new GameObject[3] { endTwo, endOne, counter};
		dodo.transform.position = endOne.transform.position;
		theta *= Mathf.Rad2Deg;
		dodo.GetComponent<Animator> ().Play ("DefaultTake");
		inPlay = true;
		StartCoroutine ("accelerate");
		print (theta);
		OpenTime = Time.time;
		Preloader.Instance.rotationType = Random.Range (0, 2) % 2 == 0 ? 1 : -1;
		if (Preloader.Instance.rotationType == -1) {
			dodo.transform.rotation = Quaternion.Euler (new Vector3 (0f, -theta, 0f));
		} else {
			dodo.transform.rotation = Quaternion.Euler (new Vector3 (0f, -theta+180f, 0f));
		}
	}

	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.inPlay && inPlay) {
			parentObject.transform.RotateAround (parentObject.transform.position, Preloader.Instance.rotationType*Vector3.up, speed*Time.deltaTime);
			dodo.transform.GetChild (0).position = new Vector3 (0f, 0f, 0f);
			if (Time.time - OpenTime > 0.5f) {
				if (Input.GetMouseButtonDown (0) && !(EventSystem.current.IsPointerOverGameObject (Input.GetTouch(0).fingerId))) {
					//Input.GetTouch(0).fingerId
					inPlay = false;	
					StartCoroutine ("Switch");
					print ("dodo rotation is " + parentObject.transform.rotation.eulerAngles);
					print ("dodo positioon is " + endOne.transform.position);
				}
			}
		}	
	}

	IEnumerator Switch(){

		//GameManager.Instance.inPlay = false;
		arSrc.PlayOneShot (Preloader.Instance.switcherSound);
		if ((dodo.transform.position - endOne.transform.position).sqrMagnitude < 1) {
			target = 2;
			CounterChecker.Instance.gameObject.transform.position = endTwo.transform.position;
			CounterChecker.Instance.counter = 0;
			CounterChecker.Instance.setStone ();
			dodo.transform.RotateAround (dodo.transform.position, Vector3.up, -90f);
			while ((dodo.transform.position - endTwo.transform.position).sqrMagnitude > 0.01f) {
				dodo.transform.position = Vector3.MoveTowards (dodo.transform.position, endTwo.transform.position, 10f * Time.deltaTime);
				yield return new WaitForEndOfFrame ();
			}
			GameManager.Instance.score++;
			IncreaseSpeed ();
			dodo.transform.RotateAround (dodo.transform.position, Vector3.up, -90f);
		} else {
			target = 1;
			CounterChecker.Instance.gameObject.transform.position = endOne.transform.position;
			CounterChecker.Instance.counter = 0;
			CounterChecker.Instance.setStone ();
			dodo.transform.RotateAround (dodo.transform.position, -Vector3.up, -90f);
			while ((dodo.transform.position - endOne.transform.position).sqrMagnitude > 0.01f) {
				dodo.transform.position = Vector3.MoveTowards (dodo.transform.position, endOne.transform.position, 10f * Time.deltaTime);
				yield return new WaitForEndOfFrame ();
			}
			GameManager.Instance.score++;
			IncreaseSpeed ();
			dodo.transform.RotateAround (dodo.transform.position, Vector3.up, -90f);
		}



		inPlay = true;
		//GameManager.Instance.inPlay = true;
	}
	void IncreaseSpeed(){
		if (GameManager.Instance.score % 10 == 0 && GameManager.Instance.score > 0 && GameManager.Instance.score <= 40) {
			speed += 10f;
		}
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("dino")) {
			StopCoroutine ("Switch");
			dino.transform.GetChild (Preloader.Instance.dino - 1).gameObject.GetComponent<Animator> ().SetBool ("gameover", true);
			gameObject.SetActive (false);
			//Vector3 temp = posArray [target - 1].transform.position;
			//Instantiate (skull, new Vector3(temp.x,temp.y+0.1f,temp.z), Quaternion.Euler(new Vector3(90f,0f,0f)));
			GameManager.Instance.inPlay = false;
			//dino.transform.GetChild(PlayerSelector.Instance.dinoChar - 1).gameObject.GetComponent<Animator> ().enabled = false;
			//newDinoMovement.animating = false;
		}
	}

	IEnumerator accelerate(){
		speed = 0f;
		while (Time.time - startTime < 3f) {
			Mathf.Clamp (speed+=0.5f, 0f, 50f);
			yield return new WaitForEndOfFrame ();
		}
		counter.transform.position = new Vector3 (radius, -0.5f, 0f);
		speed = 100f;
	}
		
		
}

/*
void Start () {
	
		endOne.transform.position = new Vector3 (radius, -0.5f, 0f);
		endTwo.transform.position = new Vector3 (-radius, -0.5f, 0f);
		posArray = new GameObject[3] { endTwo, endOne, counter};
		dodo.transform.position = endOne.transform.position;
		dodo.GetComponent<Animator> ().Play ("DefaultTake");
		inPlay = true;
		StartCoroutine ("accelerate");

}
*/


