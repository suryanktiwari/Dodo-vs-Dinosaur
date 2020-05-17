using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRenderer : MonoBehaviour {

	private TrailRenderer trail;

	// Use this for initialization
	void Start () {
		trail = gameObject.GetComponent<TrailRenderer> ();
		// A simple 2 color gradient with a fixed alpha of 1.0f.
		float alpha = 1.0f;
		Gradient gradient = new Gradient();
		gradient.SetKeys(
			new GradientColorKey[] { new GradientColorKey(Color.yellow, 0.0f), new GradientColorKey(Color.white, 1.0f) },
			new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
		);
		trail.colorGradient = gradient;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
