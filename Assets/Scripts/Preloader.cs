using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
public class Preloader : MonoBehaviour {

	public static Preloader Instance;
	public int highScore;
	public int coins;
	public int spino, bat;
	public int soundStatus;
	public int noOfGamesPlayed;
	public int signInTried=0;

	public AudioClip switcherSound, squishSound;
	public int dodo, dino;
	public int rotationType,tutorial;
	// Use this for initialization
	void Awake () {
		if (Instance == null) {
			DontDestroyOnLoad (this);
			Instance = this;

			PlayGamesPlatform.Activate ();
			PlayGamesPlatform.DebugLogEnabled = false;

			//reset ();
			if (!PlayerPrefs.HasKey ("highScore")) {
				PlayerPrefs.SetInt ("highScore", 0);
				PlayerPrefs.SetInt ("coins", 0);
				PlayerPrefs.SetInt ("spino", 0);
				PlayerPrefs.SetInt ("bat", 0);
				PlayerPrefs.SetInt ("soundStatus", 1);
				PlayerPrefs.SetInt ("dodo", 1);
				PlayerPrefs.SetInt ("dino", 1);
				PlayerPrefs.SetInt ("noOfGamesPlayed",0);
			}
			highScore = PlayerPrefs.GetInt ("highScore");
			coins = PlayerPrefs.GetInt ("coins");
			spino = PlayerPrefs.GetInt ("spino");
			bat = PlayerPrefs.GetInt ("bat");
			soundStatus = PlayerPrefs.GetInt ("soundStatus");
			dodo = PlayerPrefs.GetInt ("dodo");
			dino = PlayerPrefs.GetInt ("dino");
			noOfGamesPlayed = PlayerPrefs.GetInt ("noOfGamesPlayed");
		} else {
			Destroy (this.gameObject);
		}
	}
	public void Save(){

		PlayerPrefs.SetInt ("noOfGamesPlayed", noOfGamesPlayed);

	}
	// Update is called once per frame
	void Update () {
	}
	public void saveDodoDino(){
		PlayerPrefs.SetInt ("dodo", dodo);
		PlayerPrefs.SetInt ("dino", dino);
	}
	public void updateCoins(int amt){
		coins += amt;
		PlayerPrefs.SetInt ("coins", coins);
		//coinsText.text = "Coins : " + coins.ToString ();
	}

	public void subCoins(int amt){
		coins = amt;
		PlayerPrefs.SetInt ("coins", amt);
	}

	public void updateHighScore(int score){
		if (highScore < score) 
			highScore = score;
			
		
		PlayerPrefs.SetInt ("highScore", highScore);
	}

	public void unlockSpino(){
		PlayerPrefs.SetInt ("spino", 1);
		spino = 1;
	}

	public void unlockBat(){
		PlayerPrefs.SetInt ("bat", 1);
		bat = 1;
	}

	public void reset(){
		PlayerPrefs.DeleteAll ();
	}

	public void soundOn()
	{
		PlayerPrefs.SetInt ("soundStatus",1);
		soundStatus = 1;
	}

	public void soundOff()
	{
		PlayerPrefs.SetInt ("soundStatus",0);
		soundStatus = 0;
	}

}
