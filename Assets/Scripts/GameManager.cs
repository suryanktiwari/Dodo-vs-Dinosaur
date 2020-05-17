using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public GameObject text,parentDodo,parentDino;
	public Text curScore, higScore, curScore1,pauseHighScore;
	public int score;
	public bool inPlay;

	// Use this for initialization
	void Start () {
		Instance = this;
		inPlay = true;
		Time.timeScale = 1.0f;
		score = 0;
		gameObject.GetComponent<Animator> ().Play ("cam_anim");
		parentDodo.transform.GetChild (Preloader.Instance.dodo - 1).gameObject.SetActive (true);
		parentDino.transform.GetChild (Preloader.Instance.dino - 1).gameObject.SetActive (true);

		Preloader.Instance.noOfGamesPlayed++;
		Preloader.Instance.Save ();

	}
	
	// Update is called once per frame
	void Update () {
		if (!inPlay) {
		//	UIHandlerGameMenu.Instance.Gameover ();
		}
		text.GetComponent<Text> ().text = score.ToString ();
		curScore.text = score.ToString ();
		curScore1.text = score.ToString ();
		higScore.text = Preloader.Instance.highScore.ToString ();
		pauseHighScore.text = Preloader.Instance.highScore.ToString ();

	}
		

}
