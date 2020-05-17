using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotator : MonoBehaviour {


	// Use this for initialization
	public RectTransform initial,final,same;
	private Vector3 initPos, finalPos;
	int steps = 40;
	float stepMagnitude;
	void OnEnable () {
		same = GetComponent<RectTransform> ();
		initPos = initial.position;
		finalPos = final.position;
		stepMagnitude = (finalPos - initPos).magnitude / steps;
		PanelActive ();
	}

	public void PanelActive(){
		//panelRT.position = initPos;
		same.position = initPos;
		StartCoroutine (panelBadao ());
	}
	IEnumerator panelBadao(){
		for (int i = 1; i <= steps; i++) {
			same.position = Vector3.MoveTowards (same.position, finalPos, stepMagnitude);
			yield return new WaitForSeconds (5/steps);
		}
		gameObject.SetActive (false);
		UIHandlerGameMenu.Instance.animCoinText.GetComponent<Animation> ().Play ("textScale");
		same.position = initPos;

	}
	void Update(){
		same.rotation = Quaternion.Euler (0, 300* Time.time, 0) ;
	}



}
