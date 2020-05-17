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


	void Start () {

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
		if (ads.enabled)
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
	{  
		GameOver.SetActive (true);
		if(ads.enabled)
		if (RewardedAd.Instance.rewardBasedVideo.IsLoaded ()) {
			
			adsHints.text = "Watch Ads to continue!";
		} else {
			ads.enabled = !enabled;
			adsHints.text = "Ads not available !!!";

		}else
			adsHints.text="Continue Coming Soon";	

		LeaderBoard ob = new LeaderBoard ();
		ob.Post (GameManager.Instance.score);

		Preloader.Instance.updateHighScore (GameManager.Instance.score);
		Preloader.Instance.updateCoins (GameManager.Instance.score);

		scoreDiff = GameManager.Instance.score;
		soundObject.SetActive (false);
	}

	public void PauseMenu()
	{   
					
		Pause.SetActive (true);
		Time.timeScale = 0f;


	}

	public void restart()
	{
		SceneManager.LoadScene ("main");

	}

	public void home()
	{
		Time.timeScale = 1f;

		SceneManager.LoadScene ("Home");
	}


	public void resume(){
		Time.timeScale = 1f;
		Pause.SetActive (false);
		soundObject.SetActive (true);
	}

	public void rewardVideo(){
		    
			//RewardedAd.Instance.RequestRewardBasedVideo ();

		RewardedAd.Instance.ShowRewardBasedVideo ();
		//ContinueGame();
	}

	public void ContinueGame(){
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
		print ("yahan to pahucha re");
		soundObject.SetActive (true);
	}
		
	public void leadershow ()
	{
		LeaderBoard ob = new LeaderBoard ();
		ob.show ();
	}

}
