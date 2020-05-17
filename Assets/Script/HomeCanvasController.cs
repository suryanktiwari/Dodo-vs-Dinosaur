using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class HomeCanvasController : MonoBehaviour {

	public Button SoundButton;
	public Sprite On,Off;
	public GameObject Dino;
	public GameObject Dodo, fadeWalaPanel;
	public GameObject Panel, aboutPanel, soundObject, quitPanel;
	public GameObject UI;

	public GameObject aboutMusic;

	// Use this for initialization
	void Awake()
	{ 
		//Debug.Log ("hello");
		if (Preloader.Instance.signInTried == 0) {
			SignIn ob = new SignIn ();
			ob.login ();
			Preloader.Instance.signInTried = 1;
		}
	//	print(Preloader.Instance.soundStatus);
		if (Preloader.Instance.soundStatus == 0) {
			soundObject.SetActive (false);
			SoundButton.GetComponent<Image> ().sprite = Off;
		} else {
			soundObject.SetActive (true);
			SoundButton.GetComponent<Image> ().sprite = On;
		}

	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Panel.activeInHierarchy) {
				Panel.SetActive (false);
				UI.SetActive (true);
			} else if (aboutPanel.activeInHierarchy)
				aboutPanel.SetActive (false);
			else if (quitPanel.activeInHierarchy)
				quit ();
			else
				quitKaruChu();
		}
	}

	public void exitGame()
	{  //  print ("aa gaya idhar");
		Application.Quit ();
	}
	public void soundButton()
	{
		Sprite current = SoundButton.GetComponent<Image> ().sprite;
		if (current == On) {
			SoundButton.GetComponent<Image> ().sprite = Off;
			soundObject.SetActive(false);
			Preloader.Instance.soundOff ();
		} else {
			SoundButton.GetComponent<Image> ().sprite = On;
			soundObject.SetActive(true);
			Preloader.Instance.soundOn ();
		}
	//	print ("aaaj " + PlayerPrefs.GetInt ("soundStatus"));
	//	print (Preloader.Instance.soundStatus);
	}

	public void play()
	{
		if(PlayerPrefs.HasKey("tutorialDone"))
			{
				SceneManager.LoadScene ("main");
			}
			else
			{
				PlayerPrefs.SetInt ("tutorialDone",1);
				SceneManager.LoadScene ("tutorial");
			}
	}

	public void loadSelection()
	{  
		Panel.SetActive (true);
	//	UI.SetActive (false);

		Dodo.gameObject.GetComponent<Animation> ().Play ("Dodo_in");
		Dino.gameObject.GetComponent<Animation> ().Play ("Dino_out");
		fadeWalaPanel.gameObject.GetComponent<Animation> ().Play ("fade_in");


	}

	public void leadershow ()
	{
		LeaderBoard ob = new LeaderBoard ();
		ob.show ();
	}

	public void aboutButton()
	{
		aboutPanel.SetActive (true);
		if(Preloader.Instance.soundStatus==1)
		{
			soundObject.SetActive (false);
			aboutMusic.SetActive (true);
		}
	}

	public void closeAbout()
	{
		aboutPanel.SetActive (false);
		if (Preloader.Instance.soundStatus==1) {
			soundObject.SetActive (true);
			aboutMusic.SetActive (false);
		}
	}

	public void ShowTutorial(){
	//	Preloader.Instance.tutorial = 1;
		SceneManager.LoadScene ("tutorial");
	}

	public void quitKaruChu()
	{
		quitPanel.SetActive (true);
	}

	public void quit()
	{
		Application.Quit ();
	}

	public void noQuit()
	{
		quitPanel.SetActive (false);
	}
}
