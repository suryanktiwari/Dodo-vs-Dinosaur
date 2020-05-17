using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPath : MonoBehaviour {
	public GameObject point1, point2;
	LineRenderer lr ;

	private Ray ray1,ray2;
	private RaycastHit hit1,hit2;

	void Start () {
		lr = GetComponent<LineRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos1 = point1.transform.position, pos2 = point2.transform.position;

		lr.SetPosition (0, pos1);
		lr.SetPosition (1, pos2);
		ray1 = new Ray (pos1, pos2 - pos1);
		Physics.Raycast (ray1, out hit1, (pos2 - pos1).magnitude);
		if (hit1.collider.name == "endTwo") {
			print ("Path is clear");
		//	print(hit.collider.name);
			lr.enabled = true;
		} else {
			print ("bloked path");
			lr.enabled = false;
		}

	
	}
}
