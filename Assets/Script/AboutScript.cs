using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutScript : MonoBehaviour {


	void Start () {
		
	}

	void Update()
	{	print(transform.GetComponent<RectTransform>().position);	
		
		if (transform.GetComponent<RectTransform>().localPosition.y < 340f) {
			transform.GetComponent<RectTransform>().localPosition = (new Vector3 (-2700f, 340f, 0f));
		} else if (transform.GetComponent<RectTransform>().localPosition.y > 1000f) {
			transform.GetComponent<RectTransform>().localPosition = (new Vector3 (-2700f, 1000f, 0f));
		}
		print (transform.GetComponent<RectTransform> ().localPosition);
		print(transform.GetComponent<RectTransform>().position);	
		//print((new Vector3 (-2698f, 350f, 0f)));
	}

	public void OpenWebsite()
	{
		Debug.Log ("hello");
		Application.OpenURL ("http://www.bizarregamestudios.com");
	}

	public void OpenFacebook()
	{
		Application.OpenURL ("https://www.facebook.com/bizarregamestudios");
	}

	public void OpenInsta()
	{
		Application.OpenURL ("https://www.instagram.com/bizarregamestudios");
	}
}
