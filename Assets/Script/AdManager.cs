using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour {

	public static AdManager Instance { set; get; }

	private BannerView bannerView;
	public InterstitialAd interstitial;

	private void Start(){

		Instance = this;
		DontDestroyOnLoad (gameObject);

		#if UNITY_EDITOR
		print("Testing is on");
		#endif
		this.RequestInterstitial ();
		this.RequestBanner ();

	}


    
	// Returns an ad request with custom ad targeting.
	private AdRequest CreateAdRequest()
	{
		return new AdRequest.Builder()
					.Build();
	
	}

	private void RequestBanner()
	{
		/*not in use*/
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-4698696782574262/9134549033";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

		// Load a banner ad.
		this.bannerView.LoadAd(this.CreateAdRequest());
		this.bannerView.Hide ();
	}

	public void RequestInterstitial()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-4698696782574262/5336804633";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create an interstitial.
		this.interstitial = new InterstitialAd (adUnitId);
		print ("ad is requested");
		// Load an interstitial ad.
		this.interstitial.LoadAd (this.CreateAdRequest ());
	}
	
	public void ShowInterstitial()
		{	print ("ad is shown");
		if (this.interstitial.IsLoaded ()) {
			this.interstitial.Show ();
		} else {
			MonoBehaviour.print ("Interstitial is not ready yet");
		}

	}

	public void ShowBanner(){
		bannerView.Show ();
	}
	
	public void HideBanner(){
		bannerView.Hide ();
	}

}
