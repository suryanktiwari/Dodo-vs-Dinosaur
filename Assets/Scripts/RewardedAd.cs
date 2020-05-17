using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
public class RewardedAd : MonoBehaviour {
	private static RewardedAd instance;
	public static RewardedAd Instance{ get{ return instance;}}
	public RewardBasedVideoAd rewardBasedVideo;
	public static string OutputMessage
	{
		set { OutputMessage = value; }
	}
	void Start () {
		instance = this;
		DontDestroyOnLoad (gameObject);

		this.rewardBasedVideo = RewardBasedVideoAd.Instance;

		// RewardBasedVideoAd is a singleton, so handlers should only be registered once.
		this.rewardBasedVideo.OnAdLoaded += this.HandleRewardBasedVideoLoaded;
		this.rewardBasedVideo.OnAdFailedToLoad += this.HandleRewardBasedVideoFailedToLoad;
		this.rewardBasedVideo.OnAdOpening += this.HandleRewardBasedVideoOpened;
		this.rewardBasedVideo.OnAdStarted += this.HandleRewardBasedVideoStarted;
		this.rewardBasedVideo.OnAdRewarded += this.HandleRewardBasedVideoRewarded;
		this.rewardBasedVideo.OnAdClosed += this.HandleRewardBasedVideoClosed;
		this.rewardBasedVideo.OnAdLeavingApplication += this.HandleRewardBasedVideoLeftApplication;


	}
	private AdRequest CreateAdRequest()
	{
		return new AdRequest.Builder()
		/*	.AddTestDevice(AdRequest.TestDeviceSimulator)
			.AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
			.AddKeyword("game")
			.SetGender(Gender.Male)
			.SetBirthday(new DateTime(1985, 1, 1))
			.TagForChildDirectedTreatment(false)
			.AddExtra("color_bg", "9B30FF")*/
			.Build();
	}
	public void RequestRewardBasedVideo()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-4698696782574262/4906485837";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-4698696782574262/4906485837";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		this.rewardBasedVideo.LoadAd(this.CreateAdRequest(), adUnitId);
	}
		// Update is called once per frame
	public void ShowRewardBasedVideo()
	{
		if (this.rewardBasedVideo.IsLoaded ()) {
		this.rewardBasedVideo.Show ();
		} else {
		MonoBehaviour.print ("Reward based video ad is not ready yet");
		}
	}

		#region RewardBasedVideo callback handlers

	public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
	//	RewardedAd.Instance.ShowRewardBasedVideo ();
	}

	public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print(
		"HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);

	}

		public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
	}

		public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
	}

	public void HandleRewardBasedVideoClosed(object sender, EventArgs args)

	{
		UIHandlerGameMenu.Instance.ads.enabled = false;
		UIHandlerGameMenu.Instance.adsHints.text = "Ads limit reached";	
		MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
	}

	public void HandleRewardBasedVideoRewarded(object sender, Reward args)
	{
		//game will continue
	
		UIHandlerGameMenu.Instance.ads.enabled=!UIHandlerGameMenu.Instance.ads.enabled;
		UIHandlerGameMenu.Instance.ContinueGame();


	}

	public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
	}

	#endregion
}
