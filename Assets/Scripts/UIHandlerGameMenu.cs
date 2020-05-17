using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandlerGameMenu : MonoBehaviour {
	public static UIHandlerGameMenu Instance;

	private Animator goAnim;
	public GameObject Pause,DodoParent,DinoParent;
	public Button ads;
	// Use this for initialization
	public GameObject GameOver, soundObject;

	private int scoreDiff;
	public Text adsHints;
	public Text totalCoins;
	public bool isGameOver;
	public Transform[] movingCoinList;
	int OldCoins;
	public GameObject animCoinText;
	void Start () {
		isGameOver = false;
		Instance = this;
		scoreDiff = 0;
		//goAnim = transform.GetChild (1).GetComponent<Animator> ();
		if (Preloader.Instance.soundStatus == 0) {
			soundObject.SetActive (false);
		} else {
			soundObject.SetActive (true);
			soundObject.GetComponent<AudioSource> ().enabled = true;
		}
		if (!RewardedAd.Instance.rewardBasedVideo.IsLoaded ()) {
			RewardedAd.Instance.RequestRewardBasedVideo ();
		}
		if (!AdManager.Instance.interstitial.IsLoaded () && Preloader.Instance.noOfGamesPlayed%3==0) {
			AdManager.Instance.RequestInterstitial ();
		}
		if (!ads.enabled)
			ads.enabled = !ads.enabled;
		
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Pause.activeInHierarchy || GameOver.activeInHierarchy) {
				SceneManager.LoadScene ("Home");
			} else {
				PauseMenu ();
			}
		}

	}
	public void Gameover()
	{  	isGameOver = true;
		totalCoins.text = Preloader.Instance.coins+"";
		GameOver.SetActive (true);
		/////
		if(Preloader.Instance.noOfGamesPlayed%3==0){
			AdManager.Instance.ShowInterstitial (); 
		}
		/////
		if(ads.enabled)
		if (RewardedAd.Instance.rewardBasedVideo.IsLoaded ()) {
			
			adsHints.text = "Watch Ads to continue!";
		} else {
			ads.enabled = !enabled;
			adsHints.text = "Ads not available !!!";

		}else
			adsHints.text="Ads limit reached";	

		LeaderBoard ob = new LeaderBoard ();
		ob.Post (GameManager.Instance.score);

		Preloader.Instance.updateHighScore (GameManager.Instance.score);

		Preloader.Instance.updateCoins (GameManager.Instance.score-OldCoins);
		OldCoins = GameManager.Instance.score;

		if (!(Preloader.Instance.soundStatus == 0))
           		soundObject.SetActive (false);
		if(GameManager.Instance.score!=0){
		StartCoroutine ("CoinAnimation");
		StartCoroutine ("WaitAndDo");
		}
	}
	IEnumerator WaitAndDo(){
		print ("fuck you");
		yield return new WaitForSeconds (1.5f);
		print ("fuck all");
		totalCoins.text = Preloader.Instance.coins + "";
		print ("fuck everything");
	}
	IEnumerator CoinAnimation(){
		print ("Animation is working");
		for (int i = 0; i < movingCoinList.Length; i++) {
			movingCoinList [i].gameObject.SetActive (true);
			print (Time.time+"i is  " + i);
			yield return new WaitForSeconds (0.2f);
		
		}
	}

	public void PauseMenu()
	{   
					
		Pause.SetActive (true);
		if (!(Preloader.Instance.soundStatus == 0))
		soundObject.SetActive (false);
		Time.timeScale = 0f;
		AdManager.Instance.ShowBanner ();

	}

	public void restart()
	{ 	
		AdManager.Instance.HideBanner ();
		SceneManager.LoadScene ("main");
	}

	public void home()
	{
		Time.timeScale = 1f;
		AdManager.Instance.HideBanner ();
		SceneManager.LoadScene ("Home");
	}


	public void resume(){
		Time.timeScale = 1f;
		AdManager.Instance.HideBanner ();
		Pause.SetActive (false);
		if (!(Preloader.Instance.soundStatus == 0))
			soundObject.SetActive (true);
	}

	public void rewardVideo(){
		    
			//RewardedAd.Instance.RequestRewardBasedVideo ();

		RewardedAd.Instance.ShowRewardBasedVideo ();
		//ContinueGame();
	}

	public void ContinueGame(){
		AdManager.Instance.HideBanner ();
		if (newDodoMovement.target == 1) {			
			DodoParent.transform.GetChild(Preloader.Instance.dodo - 1).position = DodoParent.transform.GetChild(3).position;
			DodoParent.transform.GetChild(Preloader.Instance.dodo - 1).RotateAround (DodoParent.transform.GetChild(Preloader.Instance.dodo - 1).position, Vector3.up, -90f);
		} else if(newDodoMovement.target == 2){
			DodoParent.transform.GetChild(Preloader.Instance.dodo - 1).position = DodoParent.transform.GetChild(2).position;
			DodoParent.transform.GetChild(Preloader.Instance.dodo - 1).RotateAround (DodoParent.transform.GetChild(Preloader.Instance.dodo - 1).position, Vector3.up, -90f);
		}
		CounterChecker.scorePrev--;
		DodoParent.transform.GetChild (Preloader.Instance.dodo - 1).GetChild(0).gameObject.SetActive (true);
		newDodoMovement.inPlay = true;
		GameManager.Instance.inPlay = true;
		DinoParent.transform.GetChild(Preloader.Instance.dodo - 1).gameObject.GetComponent<Animator> ().enabled = true;
		GameOver.SetActive (false);
		if (!(Preloader.Instance.soundStatus == 0)) {
			Invoke ("gameOverSound", 1f);
		}
	}
	public void gameOverSound()
	{
		soundObject.SetActive (true);
	}
	public void leadershow ()
	{
		LeaderBoard ob = new LeaderBoard ();
		ob.show ();
	}

}
