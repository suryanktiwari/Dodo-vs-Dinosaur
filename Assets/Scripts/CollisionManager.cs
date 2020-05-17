using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("dodo")){
			GameManager.Instance.inPlay = false;
			print ("hello");
			UIHandlerGameMenu.Instance.Gameover ();
		}
	}
}
